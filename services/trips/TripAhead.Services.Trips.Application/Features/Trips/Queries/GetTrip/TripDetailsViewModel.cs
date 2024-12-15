namespace TripAhead.Services.Trips.Application.Features.Trips.Queries.GetTrip;

public class TripDetailsViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}