using MediatR;
using SocietySaaS.Application.Features.Units.DTOs;

namespace SocietySaaS.Application.Features.Units.Commands.CreateUnit
{
    public record CreateUnitCommand(CreateUnitRequest Request)
        : IRequest<UnitResponse>;
}