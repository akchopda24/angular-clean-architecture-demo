using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleCommand(
        Guid RoleId,
        string Name
    ) : IRequest;
}
