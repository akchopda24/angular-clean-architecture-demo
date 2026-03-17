using Microsoft.EntityFrameworkCore.Storage;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}