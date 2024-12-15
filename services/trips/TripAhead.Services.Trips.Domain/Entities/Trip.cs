using TripAhead.Libs.Common.Base;
using TripAhead.Services.Trips.Domain.Events;

namespace TripAhead.Services.Trips.Domain.Entities;

public class Trip : BaseAuditableEntity
{
    private List<TripOptionalItem> _tripOptions = new ();
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
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

    public Trip(string name, string description, string location, DateTimeOffset startDate, DateTimeOffset endDate, int maxOccupancy, decimal price)
    {
        Name = name;
        Description = description;
        Location = location;
        StartDate = startDate;
        EndDate = endDate;
        MaxOccupancy = maxOccupancy;
        Price = price;
    }

    public Trip Modify(string name, string description, string location, int maxOccupancy)
    {
        Name = name;
        Description = description;
        Location = location;
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

    public Trip AssignOptionalItem(OptionalItem optionalItem)
    {
        var tripOptionalItem = new TripOptionalItem(this, optionalItem);
        _tripOptions.Add(tripOptionalItem);
        return this;
    }

    public Trip AddOccupancy()
    {
        CurrentOccupancy += 1;
        if (CurrentOccupancy >= MaxOccupancy)
            throw new InvalidOperationException("This trip is already occupied");
        
        return this;
    }

    public Trip Publish()
    {
        IsPublished = true;
        AddDomainEvent(new TripPublished(Id));
        return this;
    }
}