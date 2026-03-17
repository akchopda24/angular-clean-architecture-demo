using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class Building : BaseEntity
    {
        public Guid SocietyId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Wing { get; set; }

        public int TotalFloors { get; set; }

        public int TotalUnits { get; set; }

        public string? Description { get; set; }

        public Society Society { get; set; } = null!;

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}
