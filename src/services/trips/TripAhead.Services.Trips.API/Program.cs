using Keycloak.AuthServices.Authentication;
using TripAhead.Services.Trips.API.Endpoints;
using TripAhead.Services.Trips.Application;
using TripAhead.Services.Trips.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var services = builder.Services;

builder.Services.AddGrpc();

services.AddKeycloakAuthentication(
    builder.Configuration, 
    options =>
{
    options.Audience = "workspaces-client";
    options.RequireHttpsMetadata = false;
});


services.AddAuthorization();

builder.AddApplicationServices();
builder.AddInfrastructureServices();

var app = builder.Build();

app.MapGrpcService<TripAhead.Services.Trips.API.Services.TripsService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/api/v1/trips")
    .WithTags("Trips API v1")
    .MapTripsEndpoints();

app.MapGroup("/api/v1/optional-items")
    .WithTags("OptionalItems API v1")
    .MapOptionalItemsEndpoints();

app.Run();