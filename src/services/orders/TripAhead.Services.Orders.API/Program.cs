using Keycloak.AuthServices.Authentication;
using TripAhead.Services.Orders.API.Endpoints;
using TripAhead.Services.Orders.Application;
using TripAhead.Services.Orders.Infrastructure;
using TripAhead.Services.Orders.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var services = builder.Services;

services.AddKeycloakWebApiAuthentication(builder.Configuration, options =>
{
    options.RequireHttpsMetadata = false;
    options.Audience = "workspaces-client";
});

services.AddAuthorization();

builder.AddApplicationServices();
builder.AddInfrastructureServices();

var app = builder.Build();

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

app.MapGroup("/api/v1/orders")
    .WithTags("Orders API v1")
    .MapOrdersEndpoints();

await app.InitialiseDatabaseAsync();

app.Run();