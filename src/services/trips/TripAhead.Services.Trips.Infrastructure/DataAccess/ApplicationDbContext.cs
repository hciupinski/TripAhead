using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TripAhead.Libs.Common.Converters;
using TripAhead.Services.Trips.Application.Interfaces;
using TripAhead.Services.Trips.Domain.Entities;

namespace TripAhead.Services.Trips.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Trip> Trips => Set<Trip>();

    public DbSet<OptionalItem> OptionalItems => Set<OptionalItem>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("trips");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}