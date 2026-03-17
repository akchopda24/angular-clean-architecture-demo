using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Buildings.DTOs;
using SocietySaaS.Domain.Entities;

namespace SocietySaaS.Application.Features.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler
        : IRequestHandler<CreateBuildingCommand, BuildingResponse>
    {
        private readonly IBuildingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBuildingCommandHandler(
            IBuildingRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BuildingResponse> Handle(
            CreateBuildingCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Building
            {
                SocietyId = request.Request.SocietyId,
                Name = request.Request.Name,
                //TotalFloors = request.Request.TotalFloors
            };

            await _repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BuildingResponse
            {
                Id = entity.Id,
                SocietyId = entity.SocietyId,
                Name = entity.Name,
                //TotalFloors = entity.TotalFloors
            };
        }
    }
}