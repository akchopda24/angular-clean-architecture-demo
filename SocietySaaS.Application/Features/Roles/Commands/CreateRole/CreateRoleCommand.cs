using MediatR;
using SocietySaaS.Application.Features.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand(string Name)
        : IRequest<RoleResponse>;
}
