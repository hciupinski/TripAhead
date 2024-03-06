using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Domain.Repositories;

public interface IOptionalItemRepository
{
    Task<List<OptionalItem>> GetAllAsync(CancellationToken cancellationToken);
    Task<OptionalItem?> FindAsync(Guid optionalItemId, CancellationToken cancellationToken);
    Task AddAsync(OptionalItem optionalItem, CancellationToken cancellationToken);
    Task UpdateAsync(OptionalItem optionalItem, CancellationToken cancellationToken);
    Task DeleteAsync(OptionalItem optionalItem, CancellationToken cancellationToken);
}