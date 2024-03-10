using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TripAhead.Infrastructure.Common.Extensions;

public static class ApplicationExtensions
{
    public static async Task<IServiceProvider> MigrateAsync<TDbContext>(this IServiceProvider services)
    where TDbContext : DbContext
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        return services;
    }
}