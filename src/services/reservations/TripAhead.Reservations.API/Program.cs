using TripAhead.Infrastructure.Common.Extensions;
using TripAhead.Reservations.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/", () => "Trips service!");

app.MapDefaultEndpoints();

await app.Services.MigrateAsync<ReservationsDbContext>();

app.Run();