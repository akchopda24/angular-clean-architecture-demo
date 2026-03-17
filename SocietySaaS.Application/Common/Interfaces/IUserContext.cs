using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IUserContext
    {
        Guid UserId { get; }
    }
}
