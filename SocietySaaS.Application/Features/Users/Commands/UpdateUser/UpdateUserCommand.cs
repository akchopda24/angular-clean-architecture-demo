using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        Guid UserId,
        string Username,
        Guid RoleId
    ) : IRequest;
}
