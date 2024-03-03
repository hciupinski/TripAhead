using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models;

public class AdditionalOption : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}