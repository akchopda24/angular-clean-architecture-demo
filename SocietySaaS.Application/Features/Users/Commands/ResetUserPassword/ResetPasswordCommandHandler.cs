using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.ResetUserPassword
{
    public class ResetPasswordCommandHandler
        : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ResetPasswordCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            ResetPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new Exception("User not found");

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