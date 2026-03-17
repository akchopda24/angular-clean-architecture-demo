namespace SocietySaaS.API.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower() ?? "";

            // Public endpoints
            if (path.StartsWith("/auth") ||
                path.StartsWith("/health") ||
                path.StartsWith("/swagger"))
            {
                await _next(context);
                return;
            }

            var tenantHeader = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(tenantHeader))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Tenant Id header is missing."
                });

                return;
            }

            if (!Guid.TryParse(tenantHeader, out var tenantId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Invalid Tenant Id format."
                });

                return;
            }

            context.Items["TenantId"] = tenantId;

            await _next(context);
        }
    }
}