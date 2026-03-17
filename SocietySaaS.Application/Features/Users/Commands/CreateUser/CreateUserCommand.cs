using MediatR;
using SocietySaaS.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(CreateUserRequest Request)
        : IRequest<UserResponse>;
}
