using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler
        : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new Exception("User not found");

            var oldHash = Convert.ToBase64String(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(
                        request.OldPassword + user.PasswordSalt)));

            if (oldHash != user.PasswordHash)
                throw new Exception("Old password incorrect");

            var salt = Guid.NewGuid().ToString();

            var hash = Convert.ToBase64String(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(
                        request.NewPassword + salt)));

            user.PasswordSalt = salt;
            user.PasswordHash = hash;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
