using TripAhead.Common;
using TripAhead.Reservations.Domain.Models;

namespace TripAhead.Reservations.Domain.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Guid tripId, Guid userId, CancellationToken cancellationToken);
}