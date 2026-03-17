using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Infrastructure.Persistence;
using SocietySaaS.Infrastructure.Persistence.Repositories;
using SocietySaaS.Infrastructure.Repositories;
using SocietySaaS.Infrastructure.Security;
using SocietySaaS.Infrastructure.Tenant;

namespace SocietySaaS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            // Tenant Provider
            services.AddScoped<ITenantProvider, TenantProvider>();

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Society Repository
            services.AddScoped<ISocietyRepository, SocietyRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            // Auth
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}