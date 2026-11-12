using ProInvoice.Domain.Abstraction.Entity;

namespace ProInvoice.Domain.Abstraction;
public interface IUnitOfWork
{
    Task CommitAsync(
     CancellationToken cancellationToken = default,
     bool checkForConcurrency = false);

    IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : BaseEntity;
}
