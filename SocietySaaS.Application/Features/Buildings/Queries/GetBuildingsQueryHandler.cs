using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Buildings.DTOs;

namespace SocietySaaS.Application.Features.Buildings.Queries.GetBuildings
{
    public class GetBuildingsQueryHandler
        : IRequestHandler<GetBuildingsQuery, List<BuildingResponse>>
    {
        private readonly IBuildingRepository _repository;

        public GetBuildingsQueryHandler(IBuildingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BuildingResponse>> Handle(
            GetBuildingsQuery request,
            CancellationToken cancellationToken)
        {
            var buildings = await _repository.GetBySocietyIdAsync(
                request.SocietyId,
                cancellationToken);

            return buildings.Select(x => new BuildingResponse
            {
                Id = x.Id,
                SocietyId = x.SocietyId,
                Name = x.Name,
                TotalFloors = x.TotalFloors
            }).ToList();
        }
    }
}