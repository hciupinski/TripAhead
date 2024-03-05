using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TripAhead.Trips.Domain.Models;
using TripAhead.Trips.Infrastructure.DataAccess;

namespace TripAhead.Trips.Infrastructure.Extensions;

public static class ApplicationExtensions
{
    public static async Task<IServiceProvider> MigrateAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TripsDbContext>();

        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        return services;
    }
}