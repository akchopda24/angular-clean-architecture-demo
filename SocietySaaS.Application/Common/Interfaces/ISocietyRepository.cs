using SocietySaaS.Domain.Entities;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface ISocietyRepository
    {
        Task AddAsync(Society entity, CancellationToken cancellationToken);

        Task<Society?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Society>> GetAllAsync(CancellationToken cancellationToken);

        Task<Society?> GetByRegistrationNumberAsync(
            string registrationNumber,
            CancellationToken cancellationToken);

        void Update(Society society);
    }
}