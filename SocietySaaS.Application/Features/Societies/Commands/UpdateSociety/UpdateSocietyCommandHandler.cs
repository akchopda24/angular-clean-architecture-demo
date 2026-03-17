using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Societies.DTOs;

namespace SocietySaaS.Application.Features.Societies.Commands.UpdateSociety
{
    public class UpdateSocietyCommandHandler
        : IRequestHandler<UpdateSocietyCommand, SocietyResponse>
    {
        private readonly ISocietyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSocietyCommandHandler(
            ISocietyRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SocietyResponse> Handle(
            UpdateSocietyCommand request,
            CancellationToken cancellationToken)
        {
            var society = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (society == null)
                throw new NotFoundException("Society not found");

            society.Address = request.Request.Address;
            society.GSTNumber = request.Request.GSTNumber;
            society.RegistrationNumber = request.Request.RegistrationNumber;

            _repository.Update(society);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SocietyResponse
            {
                Id = society.Id,
                Name = society.Name,
                Address = society.Address
            };
        }
    }
}