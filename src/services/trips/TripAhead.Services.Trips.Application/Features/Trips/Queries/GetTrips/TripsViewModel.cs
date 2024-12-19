namespace TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrips;

public record TripItemDto(Guid Id, string Name);
public class TripsViewModel
{
    public List<TripItemDto> Trips { get; set; } = new List<TripItemDto>();
}