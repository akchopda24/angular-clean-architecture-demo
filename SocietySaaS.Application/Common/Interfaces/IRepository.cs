using System.Linq.Expressions;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<List<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        void Update(T entity);

        void Remove(T entity);
    }
}