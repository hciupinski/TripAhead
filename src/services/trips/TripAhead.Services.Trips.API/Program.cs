using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using TripAhead.Services.Trips.API.Endpoints;
using TripAhead.Services.Trips.Application;
using TripAhead.Services.Trips.Infrastructure;
using TripAhead.Services.Trips.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o => { });

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddCors();

var services = builder.Services;

builder.Services.AddGrpc();

services.AddKeycloakWebApiAuthentication(builder.Configuration, options =>
{
    options.RequireHttpsMetadata = false;
    options.Audience = "workspaces-client";
});

services.AddAuthorization();

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowOrigin",
            builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

builder.AddApplicationServices();
builder.AddInfrastructureServices();

var app = builder.Build();
app.UseHttpLogging();
app.MapGrpcService<TripAhead.Services.Trips.API.Services.TripsService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
    IdentityModelEventSource.ShowPII = true;
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/api/v1/trips")
    .WithTags("Trips API v1")
    .MapTripsEndpoints();

app.MapGroup("/api/v1/optional-items")
    .WithTags("OptionalItems API v1")
    .MapOptionalItemsEndpoints();

await app.InitialiseDatabaseAsync();

app.Run();