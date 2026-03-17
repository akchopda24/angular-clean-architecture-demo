using MediatR;
using SocietySaaS.Application.Features.Buildings.DTOs;

namespace SocietySaaS.Application.Features.Buildings.Queries.GetBuildings
{
    public record GetBuildingsQuery(Guid SocietyId)
        : IRequest<List<BuildingResponse>>;
}