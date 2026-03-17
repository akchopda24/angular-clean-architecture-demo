using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role, CancellationToken cancellationToken);

        Task<Role?> GetByIdAsync(Guid id);

        Task<List<Role>> GetRolesAsync();

        Task DeleteAsync(Role role);
    }
}