using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; }

    DbSet<Invoice> Invoices { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}