using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Floors.DTOs
{
    public class CreateFloorDto
    {
        public Guid BuildingId { get; set; }

        public int FloorNumber { get; set; }

        public string? Name { get; set; }

        public int TotalUnits { get; set; }
    }
}