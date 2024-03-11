namespace TripAhead.Reservations.Domain.Exceptions;

public class ReservationExistsException : Exception
{
    public ReservationExistsException(Guid tripId, Guid userId) : base($"The reservation for user: {userId} on trip: {tripId} already exists.")
    {
        
    }
}