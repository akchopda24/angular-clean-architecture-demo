using SocietySaaS.Domain.Entities;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IUnitRepository
    {
        Task AddAsync(Unit entity, CancellationToken cancellationToken);

        Task<Unit?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Unit>> GetByFloorIdAsync(
            Guid floorId,
            CancellationToken cancellationToken);

        void Update(Unit unit);

        void Delete(Unit unit);
    }
}