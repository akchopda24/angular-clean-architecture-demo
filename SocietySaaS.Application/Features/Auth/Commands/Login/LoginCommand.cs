using MediatR;
using SocietySaaS.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(LoginRequest Request)
        : IRequest<LoginResponse>;
}
