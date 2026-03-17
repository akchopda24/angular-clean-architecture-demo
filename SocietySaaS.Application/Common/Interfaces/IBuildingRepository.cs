using SocietySaaS.Domain.Entities;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IBuildingRepository
    {
        Task AddAsync(Building entity, CancellationToken cancellationToken);

        Task<Building?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Building>> GetBySocietyIdAsync(
            Guid societyId,
            CancellationToken cancellationToken);

        void Update(Building building);

        void Delete(Building building);
    }
}