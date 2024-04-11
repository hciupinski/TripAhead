namespace TripAhead.Reservations.Contracts.Models;

public class ReservationViewModel
{
    private Guid Id { get; set; }
    public bool IsPaid { get; set; }
    public InvoiceViewModel? Invoice { get; set; }

    public List<AdditionalOptionViewModel> AdditionalOptions { get; set; } = new();
}