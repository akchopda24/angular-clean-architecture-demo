using Microsoft.EntityFrameworkCore;
using SocietySaaS.Domain.Common;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Tenant;

namespace SocietySaaS.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;

        public Guid CurrentTenantId => _tenantProvider.GetTenantId();

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        // DbSets
        public DbSet<Domain.Entities.Tenant> Tenants => Set<Domain.Entities.Tenant>();
        public DbSet<Society> Societies => Set<Society>();
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Floor> Floors => Set<Floor>();
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<Resident> Residents => Set<Resident>();
        public DbSet<UnitResident> UnitResidents => Set<UnitResident>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<UserPermission> UserPermissions => Set<UserPermission>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Unit>()
                .Property(x => x.Area)
                .HasPrecision(18, 2);

            modelBuilder.Entity<UnitResident>()
                .HasOne(x => x.Unit)
                .WithMany()
                .HasForeignKey(x => x.UnitId);

            modelBuilder.Entity<UnitResident>()
                .HasOne(x => x.Resident)
                .WithMany(x => x.UnitResidents)
                .HasForeignKey(x => x.ResidentId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.PermissionId);


            modelBuilder.Entity<UserPermission>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.PermissionId);

            modelBuilder.Entity<RolePermission>()
                .HasIndex(x => new { x.RoleId, x.PermissionId })
                .IsUnique();

            modelBuilder.Entity<UserPermission>()
                .HasIndex(x => new { x.UserId, x.PermissionId })
                .IsUnique();

            ApplyGlobalFilters(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var tenantId = CurrentTenantId;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.TenantId = tenantId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(SetGlobalFilter),
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance)!
                        .MakeGenericMethod(entityType.ClrType);

                    method.Invoke(this, new object[] { modelBuilder });
                }
            }
        }

        private void SetGlobalFilter<TEntity>(ModelBuilder builder)
            where TEntity : BaseEntity
        {
            builder.Entity<TEntity>()
                .HasQueryFilter(e =>
                    !e.IsDeleted &&
                    e.TenantId == CurrentTenantId);
        }
    }
}