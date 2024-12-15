namespace TripAhead.Services.Orders.Domain.Entities;

public class OrderOption
{
    public string Name { get; set; }
    public Guid OptionalItemId { get; set; }
    public decimal Price { get; set; }
}