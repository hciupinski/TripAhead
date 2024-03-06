using TripAhead.Common;

namespace TripAhead.Trips.Domain.Models;

public class Trip : Entity
{
    private List<TripOptionalItem> _tripOptions = new ();
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    public int MaxOccupancy { get; private set; }
    public decimal Price { get; private set; }
    public bool IsPublished { get; private set; }

    public IReadOnlyCollection<TripOptionalItem> Options => _tripOptions;
    
    private Trip()
    {
    }

    public Trip(string name, string description, DateTimeOffset startDate, DateTimeOffset endDate, int maxOccupancy, decimal price)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        MaxOccupancy = maxOccupancy;
        Price = price;
    }
}