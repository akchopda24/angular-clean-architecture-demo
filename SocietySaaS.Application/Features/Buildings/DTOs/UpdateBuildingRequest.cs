using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Buildings.DTOs
{
    public class UpdateBuildingRequest
    {
        public string Name { get; set; } = string.Empty;
        public int TotalFloors { get; set; }
    }
}
