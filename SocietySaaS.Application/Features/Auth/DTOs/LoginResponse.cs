using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Auth.DTOs
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();

        public List<string> Permissions { get; set; } = new();

        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }
    }
}