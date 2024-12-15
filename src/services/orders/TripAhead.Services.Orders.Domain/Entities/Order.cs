using TripAhead.Libs.Common.Base;

namespace TripAhead.Services.Orders.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public Guid TripId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid InvoiceId { get; set; }
    public bool IsPaid { get; set; }
    public decimal Total { get; set; }
    public List<OrderOption> Options { get; set; }
}