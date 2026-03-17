using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.API.Attributes
{
    public class AuthorizePermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permission;

        public AuthorizePermissionAttribute(string permission)
        {
            _permission = permission;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var permissionRepo =
                context.HttpContext.RequestServices
                .GetRequiredService<IPermissionRepository>();

            var userContext =
                context.HttpContext.RequestServices
                .GetRequiredService<IUserContext>();

            var hasPermission =
                await permissionRepo.HasPermissionAsync(userContext.UserId, _permission);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
