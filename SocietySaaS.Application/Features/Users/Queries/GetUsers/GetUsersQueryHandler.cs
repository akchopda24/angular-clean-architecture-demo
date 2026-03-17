using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler
        : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserResponse>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsersAsync();

            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Username = u.Username,
                IsActive = u.IsActive
            }).ToList();
        }
    }
}
