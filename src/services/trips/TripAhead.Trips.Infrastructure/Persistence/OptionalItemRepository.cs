using Microsoft.EntityFrameworkCore;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Domain.Repositories;
using TripAhead.Trips.Infrastructure.DataAccess;

namespace TripAhead.Trips.Infrastructure.Persistance;

public class OptionalItemRepository(TripsDbContext dbContext) : IOptionalItemRepository
{
    public async Task<List<OptionalItem>> GetAllAsync(CancellationToken cancellationToken)
        => await dbContext.OptionalItems.ToListAsync(cancellationToken);

    public async Task<OptionalItem?> FindAsync(Guid optionalItemId, CancellationToken cancellationToken)
        => await dbContext.OptionalItems.FindAsync(optionalItemId, cancellationToken);
    
    public async Task AddAsync(OptionalItem optionalItem, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(optionalItem, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(OptionalItem optionalItem, CancellationToken cancellationToken)
    {
        dbContext.Update(optionalItem);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(OptionalItem optionalItem, CancellationToken cancellationToken)
    {
        dbContext.OptionalItems.Remove(optionalItem);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}