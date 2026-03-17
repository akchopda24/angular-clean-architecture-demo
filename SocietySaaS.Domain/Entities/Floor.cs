using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class Floor : BaseEntity
    {
        public Guid BuildingId { get; set; }

        public int FloorNumber { get; set; }

        public string? Name { get; set; }

        public int TotalUnits { get; set; }

        public Building Building { get; set; } = null!;
    }
}