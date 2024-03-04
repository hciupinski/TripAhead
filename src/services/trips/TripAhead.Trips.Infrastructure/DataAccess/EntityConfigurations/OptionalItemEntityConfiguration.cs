using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Trips.Domain.Models;

namespace TripAhead.Trips.Infrastructure.DataAccess.EntityConfigurations;

public class OptionalItemEntityConfiguration : IEntityTypeConfiguration<OptionalItem>
{
    public void Configure(EntityTypeBuilder<OptionalItem> builder)
    {
        builder.ToTable(nameof(OptionalItem));

        builder.Property(t => t.Id)
            .ValueGeneratedNever();
    }
}