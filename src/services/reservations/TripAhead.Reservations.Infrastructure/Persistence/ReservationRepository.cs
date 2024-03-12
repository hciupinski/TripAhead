using Microsoft.EntityFrameworkCore;
using TripAhead.Reservations.Domain.Models;
using TripAhead.Reservations.Domain.Repositories;
using TripAhead.Reservations.Infrastructure.DataAccess;

namespace TripAhead.Reservations.Infrastructure.Persistence;

public class ReservationRepository(ReservationsDbContext dbContext) : IReservationRepository
{
    public async Task<List<Reservation>> GetAllAsync(CancellationToken cancellationToken)
        => await dbContext.Reservations.ToListAsync(cancellationToken);

    public async Task<bool> ExistsAsync(Guid tripId, Guid userId, CancellationToken cancellationToken)
        => await dbContext.Reservations.AnyAsync(x => x.TripId == tripId && x.UserId == userId, cancellationToken);

    public async Task<Reservation?> GetByIdentificationAsync(Guid tripId, Guid userId, CancellationToken cancellationToken)
        => await dbContext.Reservations
            .Include(x => x.AdditionalOptions)
            .FirstOrDefaultAsync(x => x.TripId == tripId && x.UserId == userId, cancellationToken);

    public async Task<Reservation?> FindAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.Reservations.FindAsync(id, cancellationToken);
    
    public async Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.Reservations
            .Include(x => x.AdditionalOptions)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task AddAsync(Reservation trip, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(trip, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Reservation trip, CancellationToken cancellationToken)
    {
        dbContext.Reservations.Update(trip);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Reservation item, CancellationToken cancellationToken)
    {
        dbContext.Reservations.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}