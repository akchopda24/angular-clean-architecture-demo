using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Units.DTOs;

namespace SocietySaaS.Application.Features.Units.Queries.GetUnits
{
    public class GetUnitsQueryHandler
        : IRequestHandler<GetUnitsQuery, List<UnitResponse>>
    {
        private readonly IUnitRepository _repository;

        public GetUnitsQueryHandler(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UnitResponse>> Handle(
            GetUnitsQuery request,
            CancellationToken cancellationToken)
        {
            var units = await _repository.GetByFloorIdAsync(
                request.FloorId,
                cancellationToken);

            return units.Select(x => new UnitResponse
            {
                Id = x.Id,
                FloorId = x.FloorId,
                UnitNumber = x.UnitNumber,
                UnitType = x.UnitType,
                Area = x.Area,
                BedroomCount = x.BedroomCount,
                BathroomCount = x.BathroomCount,
                BalconyCount = x.BalconyCount,
                ParkingSlots = x.ParkingSlots
            }).ToList();
        }
    }
}