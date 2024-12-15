using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TripAhead.Services.Orders.Application.Interfaces;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Invoice> Invoices => Set<Invoice>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("orders");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}