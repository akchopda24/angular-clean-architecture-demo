using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.DTOs
{
    public class RoleResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
