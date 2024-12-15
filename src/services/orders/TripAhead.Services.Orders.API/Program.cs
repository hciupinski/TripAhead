using Keycloak.AuthServices.Authentication;
using TripAhead.Services.Orders.API.Endpoints;
using TripAhead.Services.Orders.Application;
using TripAhead.Services.Orders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var services = builder.Services;

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

app.Run();