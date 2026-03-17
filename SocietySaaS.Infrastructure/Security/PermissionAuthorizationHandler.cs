using Microsoft.AspNetCore.Authorization;
using SocietySaaS.Application.Common.Authorization;
using SocietySaaS.Application.Common.Interfaces;
using System.Security.Claims;

namespace SocietySaaS.Infrastructure.Security
{
    public class PermissionAuthorizationHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionRepository _repository;

        public PermissionAuthorizationHandler(IPermissionRepository repository)
        {
            _repository = repository;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return;

            var userId = Guid.Parse(userIdClaim.Value);

            var hasPermission = await _repository
                .HasPermissionAsync(userId, requirement.Permission);

            if (hasPermission)
                context.Succeed(requirement);
        }
    }
}