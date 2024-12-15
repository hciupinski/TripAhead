using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Trips.Domain.Entities;

namespace TripAhead.Services.Trips.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Trip> Trips { get; }

    DbSet<OptionalItem> OptionalItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}