using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.DeactivateUser
{
    public class DeactivateUserCommandHandler
        : IRequestHandler<DeactivateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeactivateUserCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            DeactivateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new Exception("User not found");

            user.IsActive = false;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}