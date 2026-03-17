using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IPermissionRepository
    {
        Task<bool> HasPermissionAsync(Guid userId, string permission);
    }
}