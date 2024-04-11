namespace TripAhead.Reservations.Contracts.Models;

public class AdditionalOptionViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}