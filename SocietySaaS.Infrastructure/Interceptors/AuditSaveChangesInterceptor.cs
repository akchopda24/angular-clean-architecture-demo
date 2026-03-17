using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Common;
using SocietySaaS.Infrastructure.Tenant;

namespace SocietySaaS.Infrastructure.Interceptors
{
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly IUserContext _userContext;

        public AuditSaveChangesInterceptor(
            ITenantProvider tenantProvider,
            IUserContext userContext)
        {
            _tenantProvider = tenantProvider;
            _userContext = userContext;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context == null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var tenantId = _tenantProvider.GetTenantId();
            var userId = _userContext.UserId;
            var now = DateTime.UtcNow;

            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.TenantId = tenantId;
                        entry.Entity.CreatedDate = now;
                        entry.Entity.CreatedBy = userId;
                        entry.Entity.IsDeleted = false;

                        break;

                    case EntityState.Modified:

                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Property(x => x.TenantId).IsModified = false;

                        entry.Entity.ModifiedDate = now;
                        entry.Entity.ModifiedBy = userId;

                        break;

                    case EntityState.Deleted:

                        entry.State = EntityState.Modified;

                        entry.Entity.IsDeleted = true;
                        entry.Entity.ModifiedDate = now;
                        entry.Entity.ModifiedBy = userId;

                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}