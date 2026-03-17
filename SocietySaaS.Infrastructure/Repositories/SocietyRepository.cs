using Microsoft.EntityFrameworkCore;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;

namespace SocietySaaS.Infrastructure.Persistence.Repositories
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly ApplicationDbContext _context;

        public SocietyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Society entity,
            CancellationToken cancellationToken)
        {
            await _context.Societies.AddAsync(entity, cancellationToken);
        }

        public async Task<Society?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _context.Societies
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Society>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Societies
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Society?> GetByRegistrationNumberAsync(
            string registrationNumber,
            CancellationToken cancellationToken)
        {
            return await _context.Societies
                .FirstOrDefaultAsync(
                    x => x.RegistrationNumber == registrationNumber,
                    cancellationToken);
        }

        public void Update(Society society)
        {
            _context.Societies.Update(society);
        }
    }
}