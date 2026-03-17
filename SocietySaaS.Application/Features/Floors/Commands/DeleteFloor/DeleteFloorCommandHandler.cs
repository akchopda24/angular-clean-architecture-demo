using MediatR;
using SocietySaaS.Application.Common.Interfaces;

namespace SocietySaaS.Application.Features.Floors.Commands.DeleteFloor
{
    public class DeleteFloorCommandHandler
        : IRequestHandler<DeleteFloorCommand, Unit>
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            DeleteFloorCommand request,
            CancellationToken cancellationToken)
        {
            var floor = await _floorRepository.GetByIdAsync(request.Id);

            if (floor == null)
                throw new Exception("Floor not found");

            _floorRepository.Delete(floor);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}