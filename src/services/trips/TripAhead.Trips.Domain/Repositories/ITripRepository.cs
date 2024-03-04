using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Domain.Repositories;

public interface ITripRepository
{
    Task<List<Trip>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Trip trip, CancellationToken cancellationToken);
}