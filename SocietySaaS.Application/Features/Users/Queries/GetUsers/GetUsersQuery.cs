using MediatR;
using SocietySaaS.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery()
        : IRequest<List<UserResponse>>;
}
