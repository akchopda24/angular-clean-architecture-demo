using MediatR;
using SocietySaaS.Application.Features.Floors.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Floors.Commands.CreateFloor
{
    public record CreateFloorCommand(CreateFloorDto Floor) : IRequest<Guid>;
}
