using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IResidentRepository
    {
        Task AddAsync(Resident entity, CancellationToken cancellationToken);

        Task<Resident?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Resident>> GetAllAsync(CancellationToken cancellationToken);

        Task<List<UnitResident>> GetResidentsByUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken);

        Task AddUnitResidentAsync(
            UnitResident entity,
            CancellationToken cancellationToken);

        void Update(Resident resident);

        void Delete(Resident resident);
    }
}