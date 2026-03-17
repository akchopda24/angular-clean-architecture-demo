using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Infrastructure.Tenant
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
