using Microsoft.AspNetCore.Authorization;

namespace SocietySaaS.Application.Common.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute(string permission)
        {
            Policy = permission;
        }
    }
}