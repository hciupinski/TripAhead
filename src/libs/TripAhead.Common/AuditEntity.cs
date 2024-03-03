namespace TripAhead.Common;

public abstract class AuditEntity : Entity
{
    public DateTime CreatedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTime ModifiedAt { get; private set; }
    public Guid ModifiedBy { get; private set; }
}