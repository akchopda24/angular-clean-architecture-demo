using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler
        : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            DeleteRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.RoleId);

            if (role == null)
                throw new Exception("Role not found");

            role.IsDeleted = true;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}