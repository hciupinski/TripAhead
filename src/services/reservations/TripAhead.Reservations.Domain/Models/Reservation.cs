using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models;

public class Reservation : AuditEntity
{
    private List<AdditionalOption> _additionalOptions = new();
    
    public Guid UserId { get; init; }
    public Guid TripId { get; init; }
    public bool IsPaid { get; private set; }
    public Guid? InvoiceId { get; private set; }
    public virtual Invoice.Invoice Invoice { get; private set; }
    
    public IReadOnlyCollection<AdditionalOption> AdditionalOptions => _additionalOptions;
}