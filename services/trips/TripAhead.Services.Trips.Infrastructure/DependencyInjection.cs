using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TripAhead.Libs.Common.Interceptors;
using TripAhead.Libs.Common.Interfaces;
using TripAhead.Services.Trips.Application.Interfaces;
using TripAhead.Services.Trips.Infrastructure.DataAccess;
using TripAhead.Services.Trips.Infrastructure.Services;

namespace TripAhead.Services.Trips.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUser, CurrentUser>();
        builder.Services.AddHttpContextAccessor();
        
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