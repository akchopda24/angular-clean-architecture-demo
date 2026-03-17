using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler
       : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.RoleId);

            if (role == null)
                throw new Exception("Role not found");

            role.Name = request.Name;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}