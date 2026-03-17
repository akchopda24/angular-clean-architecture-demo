using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Infrastructure.Persistence;

namespace SocietySaaS.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasPermissionAsync(Guid userId, string permissionCode)
        {
            // 1️⃣ Check user override
            var userPermission = await _context.UserPermissions
                .Include(x => x.Permission)
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.Permission.Code == permissionCode);

            if (userPermission != null)
                return userPermission.IsAllowed;

            // 2️⃣ Check role permission
            var rolePermission = await (
                from ur in _context.UserRoles
                join rp in _context.RolePermissions on ur.RoleId equals rp.RoleId
                join p in _context.Permissions on rp.PermissionId equals p.Id
                where ur.UserId == userId
                && p.Code == permissionCode
                select rp
            ).AnyAsync();

            return rolePermission;
        }
    }
}