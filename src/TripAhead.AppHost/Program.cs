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
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume();
    // .WithImport("./KeycloakConfiguration/realm-export.json");

var realm = keycloak.AddRealm("tripahead");

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

// NodeJs app
var web = builder.AddNpmApp("angular", "../web/TripAhead")
    .WithReference(tripsService)
    .WaitFor(tripsService)
    .WithReference(ordersService)
    .WaitFor(ordersService)
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithHttpEndpoint(port: 4200, env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();