using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Units.DTOs;
using SocietySaaS.Domain.Entities;
using Unit = SocietySaaS.Domain.Entities.Unit;

namespace SocietySaaS.Application.Features.Units.Commands.CreateUnit
{
    public class CreateUnitCommandHandler
        : IRequestHandler<CreateUnitCommand, UnitResponse>
    {
        private readonly IUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitCommandHandler(
            IUnitRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UnitResponse> Handle(
            CreateUnitCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Unit
            {
                FloorId = request.Request.FloorId,
                UnitNumber = request.Request.UnitNumber,
                UnitType = request.Request.UnitType,
                Area = request.Request.Area,
                BedroomCount = request.Request.BedroomCount,
                BathroomCount = request.Request.BathroomCount,
                BalconyCount = request.Request.BalconyCount,
                ParkingSlots = request.Request.ParkingSlots
            };

            await _repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UnitResponse
            {
                Id = entity.Id,
                FloorId = entity.FloorId,
                UnitNumber = entity.UnitNumber,
                UnitType = entity.UnitType,
                Area = entity.Area,
                BedroomCount = entity.BedroomCount,
                BathroomCount = entity.BathroomCount,
                BalconyCount = entity.BalconyCount,
                ParkingSlots = entity.ParkingSlots
            };
        }
    }
}