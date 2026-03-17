using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.DeactivateUser
{
    public record DeactivateUserCommand(Guid UserId) : IRequest;
}
