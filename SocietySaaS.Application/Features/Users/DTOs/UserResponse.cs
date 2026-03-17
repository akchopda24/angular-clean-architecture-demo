using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.DTOs
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<string> Roles { get; set; } = new();
    }
}