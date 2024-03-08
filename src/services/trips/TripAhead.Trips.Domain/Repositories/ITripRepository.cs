using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Domain.Repositories;

public interface ITripRepository : IRepository<Trip>
{
    Task<Trip?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}