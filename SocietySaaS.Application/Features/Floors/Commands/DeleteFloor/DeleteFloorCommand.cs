using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Floors.Commands.DeleteFloor
{
    public record DeleteFloorCommand(Guid Id) : IRequest<Unit>;
}
