using TripAhead.Trips.Contracts.Enums;

namespace TripAhead.Trips.Contracts.Models;

public class OptionalItemViewModel
{
    public Guid Id { get; set; }
    public OptionalItemType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DefaultPrice { get; set; }
}