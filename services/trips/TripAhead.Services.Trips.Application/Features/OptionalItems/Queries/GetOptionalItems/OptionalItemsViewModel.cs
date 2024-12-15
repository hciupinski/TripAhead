using TripAhead.Services.Trips.Domain.Enums;

namespace TripAhead.Services.Trips.Application.Features.OptionalItems.Queries.GetOptionalItems;

public record OptionalItemDto(Guid Id, string Name, string Description, OptionalItemType Type);

public class OptionalItemsViewModel
{
    public List<OptionalItemDto> OptionalItems { get; set; } = new List<OptionalItemDto>();
}