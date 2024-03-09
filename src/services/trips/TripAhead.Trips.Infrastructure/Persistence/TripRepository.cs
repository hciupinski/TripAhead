using Microsoft.EntityFrameworkCore;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;
using TripAhead.Trips.Infrastructure.DataAccess;

namespace TripAhead.Trips.Infrastructure.Persistence;

public class TripRepository(TripsDbContext dbContext) : ITripRepository
{
    public async Task<List<Trip>> GetAllAsync(CancellationToken cancellationToken)
        => await dbContext.Trips.ToListAsync(cancellationToken);

    public async Task<Trip?> FindAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.Trips.FindAsync(id, cancellationToken);
    
    public async Task<Trip?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.Trips
            .Include(x => x.Options)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task AddAsync(Trip trip, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(trip, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Trip trip, CancellationToken cancellationToken)
    {
        dbContext.Trips.Update(trip);
        foreach (var item in trip.Options)
        {
            dbContext.Entry(item).State = !dbContext.OptionalItems.Any(x => x.Id == item.Id)
                ? EntityState.Added
                : EntityState.Modified;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Trip item, CancellationToken cancellationToken)
    {
        dbContext.Trips.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}