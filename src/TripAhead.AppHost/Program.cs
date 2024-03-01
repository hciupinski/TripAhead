var builder = DistributedApplication.CreateBuilder(args);

var tripsService = builder.AddProject<Projects.TripAhead_Trips_Api>("tripsservice");

builder.AddProject<Projects.TripAhead_Web>("webfrontend")
    .WithReference(tripsService);

builder.Build().Run();