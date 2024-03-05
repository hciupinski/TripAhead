using TripAhead.Trips.API.Apis;
using TripAhead.Trips.Infrastructure;
using TripAhead.Trips.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("con" + builder.Configuration.GetConnectionString("TripContext"));
// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapGroup("/api/v1/trips")
    .WithTags("Trip API")
    .MapTripApi();

await app.Services.MigrateAsync();

app.Run();