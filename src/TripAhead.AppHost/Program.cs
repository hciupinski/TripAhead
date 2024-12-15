var builder = DistributedApplication.CreateBuilder(args);

// Databases
var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);
var postgres = builder.AddPostgres("postgres", username, password)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin();
var database = postgres.AddDatabase("TripAheadDb");

// Identity Providers

var keycloak = builder
    .AddKeycloakContainer("keycloak")
    .WithDataVolume()
    .WithImport("./KeycloakConfiguration/Test-realm.json")
    .WithImport("./KeycloakConfiguration/Test-users-0.json");

var realm = keycloak.AddRealm("Test");


// API apps
var tripsService =
    builder.AddProject<Projects.TripAhead_Services_Trips_API>("tripsservice")
        .WaitFor(database)
        .WithReference(keycloak)
        .WithReference(realm)
        .WithReference(database);

var ordersService =
    builder.AddProject<Projects.TripAhead_Services_Orders_API>("ordersservice")
        .WaitFor(database)
        .WithReference(keycloak)
        .WithReference(realm)
        .WithReference(database);

builder.Build().Run();