using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Societies.DTOs;
using SocietySaaS.Domain.Entities;

namespace SocietySaaS.Application.Features.Societies.Commands.CreateSociety
{
    public class CreateSocietyCommandHandler
        : IRequestHandler<CreateSocietyCommand, SocietyResponse>
    {
        private readonly ISocietyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSocietyCommandHandler(
            ISocietyRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SocietyResponse> Handle(
            CreateSocietyCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Society
            {
                Name = request.Request.Name,
                Address = request.Request.Address,
                RegistrationNumber = request.Request.RegistrationNumber,
                GSTNumber = request.Request.GSTNumber
            };

            await _repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SocietyResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address
            };
        }
    }
}