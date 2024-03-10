using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models;

public class AdditionalOption : Entity
{
    public Guid TripAdditionalOptionId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}