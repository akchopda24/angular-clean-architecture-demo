using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid? ResidentId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string PasswordSalt { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public Resident? Resident { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
            = new List<UserRole>();
        public ICollection<UserPermission> UserPermissions { get; set; }
            = new List<UserPermission>();
    }
}
