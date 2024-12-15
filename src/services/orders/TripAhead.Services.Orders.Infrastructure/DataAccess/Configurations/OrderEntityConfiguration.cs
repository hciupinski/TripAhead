using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Services.Orders.Domain.Entities;

namespace TripAhead.Services.Orders.Infrastructure.DataAccess.Configurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(c => c.Options, d =>
            {
                d.ToJson();
            });
    }
}