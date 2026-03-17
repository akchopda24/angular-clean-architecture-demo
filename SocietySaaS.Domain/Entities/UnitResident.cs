using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class UnitResident : BaseEntity
    {
        public Guid UnitId { get; set; }

        public Guid ResidentId { get; set; }

        public string ResidentType { get; set; } = string.Empty; // Owner/Tenant/Family

        public DateTime MoveInDate { get; set; }

        public DateTime? MoveOutDate { get; set; }

        public bool IsPrimary { get; set; }

        public Unit Unit { get; set; } = null!;

        public Resident Resident { get; set; } = null!;
    }
}