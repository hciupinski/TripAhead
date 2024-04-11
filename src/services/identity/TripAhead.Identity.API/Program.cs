 using Microsoft.AspNetCore.Identity;
using TripAhead.Identity.API;
using TripAhead.Identity.Api.DataAccess;
using TripAhead.Identity.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ApplicationDbContext>("identitydb");

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/", () => "Identity service!");

app.MapDefaultEndpoints();

app.Run();