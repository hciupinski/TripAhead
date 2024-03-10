using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripAhead.Reservations.Application.Features.Reservations.Queries;
using TripAhead.Reservations.Domain.Repositories;
using TripAhead.Reservations.Infrastructure.DataAccess;
using TripAhead.Reservations.Infrastructure.Persistence;

namespace TripAhead.Reservations.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddServices()
            .AddPersistance(configuration);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetReservations).Assembly));

        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReservationsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ReservationContext")));

        services.AddScoped<IReservationRepository, ReservationRepository>();

        return services;
    }
}