using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocietySaaS.Domain.Common;

namespace SocietySaaS.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public bool IsActive { get; set; }

        public string? SubscriptionPlan { get; set; }
    }
}
