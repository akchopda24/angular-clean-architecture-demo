using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler
        : IRequestHandler<GetRolesQuery, List<RoleResponse>>
    {
        private readonly IRoleRepository _repository;

        public GetRolesQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleResponse>> Handle(
            GetRolesQuery request,
            CancellationToken cancellationToken)
        {
            var roles = await _repository.GetRolesAsync();

            return roles.Select(x => new RoleResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}