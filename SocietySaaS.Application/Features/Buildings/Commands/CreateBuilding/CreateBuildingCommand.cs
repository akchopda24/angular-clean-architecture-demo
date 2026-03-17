using MediatR;
using SocietySaaS.Application.Features.Buildings.DTOs;

namespace SocietySaaS.Application.Features.Buildings.Commands.CreateBuilding
{
    public record CreateBuildingCommand(CreateBuildingRequest Request)
        : IRequest<BuildingResponse>;
}