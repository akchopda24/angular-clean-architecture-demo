using MediatR;
using SocietySaaS.Application.Common.Interfaces;

namespace SocietySaaS.Application.Features.Floors.Commands.UpdateFloor
{
    public class UpdateFloorCommandHandler
        : IRequestHandler<UpdateFloorCommand, Unit>
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            UpdateFloorCommand request,
            CancellationToken cancellationToken)
        {
            var floor = await _floorRepository.GetByIdAsync(request.Floor.Id);

            if (floor == null)
                throw new Exception("Floor not found");

            floor.FloorNumber = request.Floor.FloorNumber;
            floor.Name = request.Floor.Name;
            floor.TotalUnits = request.Floor.TotalUnits;

            _floorRepository.Update(floor);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}