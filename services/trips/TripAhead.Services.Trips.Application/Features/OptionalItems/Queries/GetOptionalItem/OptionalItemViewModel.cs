using TripAhead.Services.Trips.Domain.Enums;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItem;

public class OptionalItemViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public OptionalItemType Type { get; set; }
    
    public decimal? Price { get; set; }
}