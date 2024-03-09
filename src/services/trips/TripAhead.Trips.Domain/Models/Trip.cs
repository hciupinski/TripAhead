using TripAhead.Common;
using TripAhead.Trips.Domain.Events;

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
    
    public int CurrentOccupancy { get; private set; }

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

    public Trip Modify(string name, string description, int maxOccupancy)
    {
        Name = name;
        Description = description;
        MaxOccupancy = maxOccupancy;
        return this;
    }

    public Trip SetDate(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        StartDate = startDate;
        EndDate = endDate;

        return this;
    }

    public Trip SetPrice(decimal price)
    {
        Price = price;
        return this;
    }

    public Trip AssignOptionalItems(List<TripOptionalItem> chosenOptionalItems)
    {
        _tripOptions.Clear();
        _tripOptions.AddRange(chosenOptionalItems);
        return this;
    }

    public Trip Publish()
    {
        IsPublished = true;
        _domainEvents.Add(new TripPublished(Id));
        return this;
    }
}