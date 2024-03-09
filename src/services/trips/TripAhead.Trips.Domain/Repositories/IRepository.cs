using TripAhead.Common;

namespace TripAhead.Trips.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(TEntity item, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity item, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity item, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}