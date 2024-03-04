using TripAhead.Trips.API.Apis;
using TripAhead.Trips.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapGroup("/api/v1/trips")
    .WithTags("Trip API")
    .MapTripApi();

app.Run();