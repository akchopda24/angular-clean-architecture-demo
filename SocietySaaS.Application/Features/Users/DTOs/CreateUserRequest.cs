using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.DTOs
{
    public class CreateUserRequest
    {
        public Guid? ResidentId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Guid RoleId { get; set; }
    }
}
