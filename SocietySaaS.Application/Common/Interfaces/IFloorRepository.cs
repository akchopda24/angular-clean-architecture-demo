using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IFloorRepository
    {
        Task<Floor?> GetByIdAsync(Guid id);

        Task<List<Floor>> GetByBuildingIdAsync(Guid buildingId);

        Task AddAsync(Floor floor);

        void Update(Floor floor);

        void Delete(Floor floor);
    }
}