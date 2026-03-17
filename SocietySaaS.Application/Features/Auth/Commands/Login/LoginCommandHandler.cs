using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Auth.DTOs;
using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtTokenGenerator _jwt;
        private readonly IPasswordHasher _hasher;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(
            IAuthRepository repository,
            IJwtTokenGenerator jwt,
            IPasswordHasher hasher,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _jwt = jwt;
            _hasher = hasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponse> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository
                .GetUserByUsernameAsync(request.Request.Username);

            if (user == null)
                throw new Exception("Invalid username or password");

            var valid = _hasher.Verify(
                request.Request.Password,
                user.PasswordHash,
                user.PasswordSalt);

            if (!valid)
                throw new Exception("Invalid username or password");

            var accessToken = _jwt.GenerateToken(user);

            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };

            await _repository.AddRefreshTokenAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(15)
            };
        }
    }
}