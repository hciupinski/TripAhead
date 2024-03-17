namespace TripAhead.Trips.Contracts.Models;

public class TripViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get;  set; }
    public DateTimeOffset EndDate { get;  set; }
    public int MaxOccupancy { get;  set; }
    public decimal Price { get;  set; }
    public bool IsPublished { get;  set; }
    public int CurrentOccupancy { get;  set; }
    public List<OptionalItemViewModel> OptionalItems { get; set; } = new();
}