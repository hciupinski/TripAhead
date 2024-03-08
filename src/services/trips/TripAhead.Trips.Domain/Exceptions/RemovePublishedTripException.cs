namespace TripAhead.Trips.Domain.Exceptions;

public class RemovePublishedTripException : Exception
{
    public RemovePublishedTripException() : base("Cannot remove published trip.")
    {
    }
}