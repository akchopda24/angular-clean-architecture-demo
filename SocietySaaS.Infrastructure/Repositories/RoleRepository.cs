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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role role, CancellationToken cancellationToken)
        {
            await _context.Roles.AddAsync(role, cancellationToken);
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            role.IsDeleted = true;
            await Task.CompletedTask;
        }
    }
}