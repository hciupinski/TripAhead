using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripAhead.Trips.Domain.Repositories;
using TripAhead.Trips.Infrastructure.DataAccess;
using TripAhead.Trips.Infrastructure.Persistance;

namespace TripAhead.Trips.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistance(configuration);

        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TripsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TripContext")));

        services.AddScoped<ITripRepository, TripRepository>();

        return services;
    }
}