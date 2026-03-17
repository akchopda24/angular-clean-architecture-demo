using Microsoft.AspNetCore.Http;
using SocietySaaS.Application.Common.Interfaces;

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
            var context = _httpContextAccessor.HttpContext;

            if (context == null)
                throw new InvalidOperationException("HttpContext not available.");

            if (!context.Items.TryGetValue("TenantId", out var tenantIdObj))
                throw new InvalidOperationException("Tenant Id not resolved.");

            if (tenantIdObj is not Guid tenantId)
                throw new InvalidOperationException("Tenant Id is invalid.");

            return tenantId;
        }
    }
}