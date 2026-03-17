using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Infrastructure.Tenant
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetTenantId()
        {
            var tenantHeader = _httpContextAccessor.HttpContext?
                .Request.Headers["X-Tenant-Id"]
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(tenantHeader))
                throw new Exception("Tenant Id is missing in request header.");

            return Guid.Parse(tenantHeader);
        }
    }
}
