using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Floors.DTOs;

namespace SocietySaaS.Application.Features.Floors.Queries
{
    public class GetFloorsByBuildingQueryHandler
        : IRequestHandler<GetFloorsByBuildingQuery, List<FloorDto>>
    {
        private readonly IFloorRepository _floorRepository;

        public GetFloorsByBuildingQueryHandler(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public async Task<List<FloorDto>> Handle(
            GetFloorsByBuildingQuery request,
            CancellationToken cancellationToken)
        {
            var floors = await _floorRepository.GetByBuildingIdAsync(request.BuildingId);

            return floors.Select(x => new FloorDto
            {
                Id = x.Id,
                BuildingId = x.BuildingId,
                FloorNumber = x.FloorNumber,
                Name = x.Name,
                TotalUnits = x.TotalUnits
            }).ToList();
        }
    }
}