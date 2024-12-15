using TripAhead.Libs.Common.Base;
using TripAhead.Services.Trips.Domain.Enums;

namespace TripAhead.Services.Trips.Domain.Entities;

public class OptionalItem : BaseEntity
{
    public OptionalItemType Type { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal DefaultPrice { get; set; }
    
    private OptionalItem() {}

    public OptionalItem(OptionalItemType type, string name, string description, decimal price)
    {
        Type = type;
        Name = name;
        Description = description;
        DefaultPrice = price;
    }

    public OptionalItem Modify(string name, string description)
    {
        Name = name;
        Description = description;
        return this;
    }

    public OptionalItem SetPrice(decimal price)
    {
        DefaultPrice = price;
        return this;
    }
}