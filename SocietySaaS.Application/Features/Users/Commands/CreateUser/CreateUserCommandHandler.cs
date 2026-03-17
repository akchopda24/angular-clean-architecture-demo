using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Users.DTOs;
using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var salt = Guid.NewGuid().ToString();

            var hash = Convert.ToBase64String(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(
                        request.Request.Password + salt)));

            var user = new User
            {
                ResidentId = request.Request.ResidentId,
                Username = request.Request.Username,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _repository.AddAsync(user, cancellationToken);

            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = request.Request.RoleId
            };

            await _repository.AddUserRoleAsync(userRole, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}
