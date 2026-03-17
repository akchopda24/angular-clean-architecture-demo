using MediatR;
using SocietySaaS.Application.Features.Resident.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.Commands.AssignResidentToUnit
{
    public record AssignResidentToUnitCommand(
        AssignResidentToUnitRequest Request)
        : IRequest<bool>;
}
