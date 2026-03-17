using MediatR;
using SocietySaaS.Application.Features.Resident.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.Commands.CreateResident
{
    public record CreateResidentCommand(CreateResidentRequest Request)
        : IRequest<ResidentResponse>;
}
