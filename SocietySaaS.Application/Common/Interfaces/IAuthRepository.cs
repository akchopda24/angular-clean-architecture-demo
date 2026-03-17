using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);

        Task AddRefreshTokenAsync(RefreshToken token);

        Task<RefreshToken?> GetRefreshTokenAsync(string token);
    }
}