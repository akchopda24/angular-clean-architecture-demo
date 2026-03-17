using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User entity, CancellationToken cancellationToken);

        Task<User?> GetByUsernameAsync(
            string username,
            CancellationToken cancellationToken);

        Task AddUserRoleAsync(
            UserRole entity,
            CancellationToken cancellationToken);

        Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);

        Task<User?> GetByIdAsync(Guid id);

        Task<List<User>> GetUsersAsync();

        Task UpdateUserRoleAsync(Guid userId, Guid roleId);
    }
}