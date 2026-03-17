using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;

namespace SocietySaaS.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Unit entity,
            CancellationToken cancellationToken)
        {
            await _context.Units.AddAsync(entity, cancellationToken);
        }

        public async Task<Unit?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _context.Units
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Unit>> GetByFloorIdAsync(
            Guid floorId,
            CancellationToken cancellationToken)
        {
            return await _context.Units
                .Where(x => x.FloorId == floorId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public void Update(Unit unit)
        {
            _context.Units.Update(unit);
        }

        public void Delete(Unit unit)
        {
            unit.IsDeleted = true;
            _context.Units.Update(unit);
        }
    }
}