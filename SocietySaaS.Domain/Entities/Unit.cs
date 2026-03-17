using SocietySaaS.Domain.Common;

namespace SocietySaaS.Domain.Entities
{
    public class Unit : BaseEntity
    {
        public Guid FloorId { get; set; }

        public string UnitNumber { get; set; } = string.Empty;

        public string? UnitType { get; set; }

        public decimal? Area { get; set; }

        public int? BedroomCount { get; set; }

        public int? BathroomCount { get; set; }

        public int? BalconyCount { get; set; }

        public int? ParkingSlots { get; set; }

        public string? OwnershipType { get; set; }

        public string? Status { get; set; }

        public bool IsActive { get; set; } = true;

        public Floor Floor { get; set; } = null!;
    }
}