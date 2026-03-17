using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class UserPermission : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public bool IsAllowed { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}