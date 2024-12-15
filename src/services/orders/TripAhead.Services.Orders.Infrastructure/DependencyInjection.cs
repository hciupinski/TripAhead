using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TripAhead.Libs.Common.Interceptors;
using TripAhead.Libs.Common.Interfaces;
using TripAhead.Services.Orders.Application.Interfaces;
using TripAhead.Services.Orders.Infrastructure.DataAccess;
using TripAhead.Services.Orders.Infrastructure.Services;
using TripsService;

namespace TripAhead.Services.Orders.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUser, CurrentUser>();
        builder.Services.AddHttpContextAccessor();
        
        builder.Services.AddGrpcClient<Trips.TripsClient>(options =>
        {
            options.Address = new Uri("https://localhost:6001");
        });
        builder.Services.AddScoped<ITripsServiceClient, TripsServiceClient>();
        
        var connectionString = builder.Configuration.GetConnectionString("TripAheadDb");
        Guard.Against.Null(connectionString, message: "Connection string 'TripAheadDb' not found.");

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });
        
        builder.EnrichNpgsqlDbContext<ApplicationDbContext>();
        
        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        builder.Services.AddScoped<ApplicationDbContextInitialiser>();
    }
}