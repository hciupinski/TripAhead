using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models;

public class AdditionalOption
{
    public Guid TripAdditionalOptionId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public AdditionalOption(Guid optionId, string name, decimal price)
    {
        TripAdditionalOptionId = optionId;
        Name = name;
        Price = price;
    }
}