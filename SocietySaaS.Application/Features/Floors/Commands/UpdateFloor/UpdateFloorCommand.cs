using MediatR;
using SocietySaaS.Application.Features.Floors.DTOs;

namespace SocietySaaS.Application.Features.Floors.Commands.UpdateFloor
{
    public record UpdateFloorCommand(UpdateFloorDto Floor) : IRequest<Unit>;
}