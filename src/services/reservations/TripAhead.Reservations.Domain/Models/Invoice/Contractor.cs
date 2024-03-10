using System.ComponentModel.DataAnnotations.Schema;
using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models.Invoice;

[ComplexType]
public class Contractor : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Name { get; private set; }
    public string? Identifier { get; private set; }
}