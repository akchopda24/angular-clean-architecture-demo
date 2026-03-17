using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Buildings.DTOs
{
    public class BuildingResponse
    {
        public Guid Id { get; set; }
        public Guid SocietyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalFloors { get; set; }
    }
}
