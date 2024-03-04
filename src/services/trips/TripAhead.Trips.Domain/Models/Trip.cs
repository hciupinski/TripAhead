using TripAhead.Common;

namespace TripAhead.Trips.Domain.Models;

public class Trip : Entity
{
    private List<OptionalItem> _optionalItems = new ();
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int MaxOccupancy { get; private set; }
    public decimal Price { get; private set; }
    public bool IsPublished { get; private set; }

    public IReadOnlyCollection<OptionalItem> OptionalItems => _optionalItems;
    
    private Trip()
    {
    }

    public Trip(string name, string description, DateTime startDate, DateTime endDate, int maxOccupancy, decimal price)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        MaxOccupancy = maxOccupancy;
        Price = price;
    }
}