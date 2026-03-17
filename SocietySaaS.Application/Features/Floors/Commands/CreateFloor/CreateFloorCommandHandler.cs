using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Floors.Commands.CreateFloor
{
    public class CreateFloorCommandHandler : IRequestHandler<CreateFloorCommand, Guid>
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateFloorCommand request, CancellationToken cancellationToken)
        {
            var floor = new Floor
            {
                Id = Guid.NewGuid(),
                BuildingId = request.Floor.BuildingId,
                FloorNumber = request.Floor.FloorNumber,
                Name = request.Floor.Name,
                TotalUnits = request.Floor.TotalUnits
            };

            await _floorRepository.AddAsync(floor);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return floor.Id;
        }
    }
}
