var builder = DistributedApplication.CreateBuilder(args);

var tripsService = builder.AddProject<Projects.TripAhead_Trips_Api>("tripsservice");
var reservationsService = builder.AddProject<Projects.TripAhead_Reservations_API>("reservationsservice");

builder.AddProject<Projects.TripAhead_Web>("webfrontend")
    .WithReference(tripsService)
    .WithReference(reservationsService);

builder.Build().Run();