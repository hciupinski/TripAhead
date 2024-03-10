using TripAhead.Common;

namespace TripAhead.Reservations.Domain.Models.Invoice;


public class Invoice : Entity
{
    private List<LineItem> _items { get; set; } = new();
    
    public Contractor Seller { get; private set; }
    public Contractor Buyer { get; private set; }

    public string Title { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }

    public IReadOnlyList<LineItem> Items => _items;
    public string Comments { get; set; }
    public string FilePath { get; private set; }

    public Guid ReservationId { get; init; }
    public Reservation Reservation { get; init; }

    private Invoice()
    {
    }

    public Invoice(string title, string invoiceNumber, DateTime issueDate, DateTime dueDate,
        string comments)
    {
        Title = title;
        InvoiceNumber = invoiceNumber;
        IssueDate = issueDate;
        DueDate = dueDate;
        Comments = comments;
    }

    public Invoice AddLineItem(LineItem lineItem)
    {
        _items.Add(lineItem);
        return this;
    }
}