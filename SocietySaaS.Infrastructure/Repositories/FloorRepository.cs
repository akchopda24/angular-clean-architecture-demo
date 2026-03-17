using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;

namespace SocietySaaS.Infrastructure.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly ApplicationDbContext _context;

        public FloorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Floor?> GetByIdAsync(Guid id)
        {
            return await _context.Floors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Floor>> GetByBuildingIdAsync(Guid buildingId)
        {
            return await _context.Floors
                .Where(x => x.BuildingId == buildingId)
                .ToListAsync();
        }

        public async Task AddAsync(Floor floor)
        {
            await _context.Floors.AddAsync(floor);
        }

        public void Update(Floor floor)
        {
            _context.Floors.Update(floor);
        }

        public void Delete(Floor floor)
        {
            floor.IsDeleted = true;
            _context.Floors.Update(floor);
        }
    }
}