using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.DTOs
{
    public class AssignResidentToUnitRequest
    {
        public Guid UnitId { get; set; }

        public Guid ResidentId { get; set; }

        public string ResidentType { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }
    }
}