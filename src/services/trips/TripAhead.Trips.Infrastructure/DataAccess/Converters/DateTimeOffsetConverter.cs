using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TripAhead.Trips.Infrastructure.DataAccess.Converters;

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter()
        : base(
            d => d.ToUniversalTime(),
            d => d.ToUniversalTime())
    {
    }
}