using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class Resident : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<UnitResident> UnitResidents { get; set; }
            = new List<UnitResident>();
    }
}