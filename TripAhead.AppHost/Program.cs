var builder = DistributedApplication.CreateBuilder(args);

// Databases

var postgres = builder.AddPostgres("postgres").WithPgAdmin();
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
    .WithReference(keycloak)
    .WithReference(realm)
    .WithReference(database);

var orderssService =
    builder.AddProject<Projects.TripAhead_Services_Orders_API>("ordersservice")
        .WithReference(keycloak)
        .WithReference(realm)
        .WithReference(database);

builder.Build().Run();