using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripAhead.Reservations.Domain.Models.Invoice;

namespace TripAhead.Reservations.Infrastructure.DataAccess.EntityConfigurations;

public class LineItemEntityConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable(nameof(LineItem));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Net).IsRequired();
        builder.Property(x => x.Gross).IsRequired();
        builder.Property(x => x.Tax).IsRequired();
        builder.Property(x => x.TaxRate).IsRequired();
        builder.Property(x => x.Unit).IsRequired();
    }
}