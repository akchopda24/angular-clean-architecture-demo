using MediatR;
using SocietySaaS.Application.Features.Floors.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Floors.Queries
{
    public record GetFloorsByBuildingQuery(Guid BuildingId) : IRequest<List<FloorDto>>;
}
