using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Roles.DTOs;
using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, RoleResponse>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RoleResponse> Handle(
            CreateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Name = request.Name
            };

            await _repository.AddAsync(role, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new RoleResponse
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
