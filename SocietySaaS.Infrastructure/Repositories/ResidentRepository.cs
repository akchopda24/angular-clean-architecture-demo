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
    public class ResidentRepository : IResidentRepository
    {
        private readonly ApplicationDbContext _context;

        public ResidentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Resident entity,
            CancellationToken cancellationToken)
        {
            await _context.Residents.AddAsync(entity, cancellationToken);
        }

        public async Task<Resident?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _context.Residents
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Resident>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Residents
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<UnitResident>> GetResidentsByUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken)
        {
            return await _context.UnitResidents
                .Include(x => x.Resident)
                .Where(x => x.UnitId == unitId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddUnitResidentAsync(
            UnitResident entity,
            CancellationToken cancellationToken)
        {
            await _context.UnitResidents.AddAsync(entity, cancellationToken);
        }

        public void Update(Resident resident)
        {
            _context.Residents.Update(resident);
        }

        public void Delete(Resident resident)
        {
            resident.IsDeleted = true;
            _context.Residents.Update(resident);
        }
    }
}
