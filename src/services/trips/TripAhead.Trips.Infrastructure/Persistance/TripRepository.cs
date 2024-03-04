using Microsoft.EntityFrameworkCore;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;
using TripAhead.Trips.Infrastructure.DataAccess;

namespace TripAhead.Trips.Infrastructure.Persistance;

public class TripRepository(TripsDbContext dbContext) : ITripRepository
{
    public async Task<List<Trip>> GetAllAsync(CancellationToken cancellationToken)
        => await dbContext.Trips.ToListAsync(cancellationToken);

    public async Task AddAsync(Trip trip, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(trip, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}