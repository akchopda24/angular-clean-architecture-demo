using MediatR;
using SocietySaaS.Application.Features.Units.DTOs;

namespace SocietySaaS.Application.Features.Units.Queries.GetUnits
{
    public record GetUnitsQuery(Guid FloorId)
        : IRequest<List<UnitResponse>>;
}