using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models.Invoice;

public class LineItem : Entity
{
    public string Name { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }
    public decimal Net { get; set; }
    public decimal Tax { get; set; }
    public decimal TaxRate { get; set; }
    public decimal Gross { get; set; }
    public int Quantity { get; set; }

    public Guid InvoiceId { get; set; }

    private LineItem()
    {
    }

    public LineItem(Guid invoiceId, string name, string unit, decimal price, decimal net, decimal tax, decimal taxRate,
        decimal gross, int quantity)
    {
        InvoiceId = invoiceId;
        Name = name;
        Unit = unit;
        Price = price;
        Quantity = quantity;
        TaxRate = taxRate;

        Calculate();
    }

    public LineItem Calculate()
    {
        Net = Price * Quantity;
        Tax = Net * TaxRate;
        Gross = Net + Tax;

        return this;
    }
}