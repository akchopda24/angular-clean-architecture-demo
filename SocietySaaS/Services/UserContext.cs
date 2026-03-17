using SocietySaaS.Application.Common.Interfaces;
using System.Security.Claims;

namespace SocietySaaS.API.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;

                var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdClaim, out var userId))
                    return userId;

                // Temporary fallback for development
                return Guid.Parse("11111111-1111-1111-1111-111111111111");
            }
        }
    }
}
