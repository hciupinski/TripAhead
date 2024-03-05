using TripAhead.Common;
using TripAhead.Trips.Domain.Enums;

namespace TripAhead.Trips.Domain.Models;

public class OptionalItem : Entity
{
    public OptionalItemType Type { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal DefaultPrice { get; set; }
    
    public virtual List<TripOptionalItem> TripOptionalItems { get; set; }
    
    private OptionalItem() {}

    public OptionalItem(OptionalItemType type, string name, string description)
    {
        Type = type;
    }
}