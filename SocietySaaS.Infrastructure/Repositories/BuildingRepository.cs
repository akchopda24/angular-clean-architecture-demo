using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _context;

        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Building entity,
            CancellationToken cancellationToken)
        {
            await _context.Buildings.AddAsync(entity, cancellationToken);
        }

        public async Task<Building?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _context.Buildings
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Building>> GetBySocietyIdAsync(
            Guid societyId,
            CancellationToken cancellationToken)
        {
            return await _context.Buildings
                .Where(x => x.SocietyId == societyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public void Update(Building building)
        {
            _context.Buildings.Update(building);
        }

        public void Delete(Building building)
        {
            building.IsDeleted = true;
            _context.Buildings.Update(building);
        }
    }
}