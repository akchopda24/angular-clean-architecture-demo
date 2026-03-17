using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            User entity,
            CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(entity, cancellationToken);
        }

        public async Task<User?> GetByUsernameAsync(
            string username,
            CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(
                    x => x.Username == username,
                    cancellationToken);
        }

        public async Task AddUserRoleAsync(
            UserRole entity,
            CancellationToken cancellationToken)
        {
            await _context.UserRoles.AddAsync(entity, cancellationToken);
        }

        public async Task<List<Role>> GetRolesAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Roles
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateUserRoleAsync(Guid userId, Guid roleId)
        {
            var existingRoles = await _context.UserRoles
                .Where(x => x.UserId == userId)
                .ToListAsync();

            _context.UserRoles.RemoveRange(existingRoles);

            await _context.UserRoles.AddAsync(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}
