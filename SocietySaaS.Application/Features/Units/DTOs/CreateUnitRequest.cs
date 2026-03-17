namespace SocietySaaS.Application.Features.Units.DTOs
{
    public class CreateUnitRequest
    {
        public Guid FloorId { get; set; }

        public string UnitNumber { get; set; } = string.Empty;

        public string? UnitType { get; set; }

        public decimal? Area { get; set; }

        public int? BedroomCount { get; set; }

        public int? BathroomCount { get; set; }

        public int? BalconyCount { get; set; }

        public int? ParkingSlots { get; set; }
    }
}