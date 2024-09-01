var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.KluskaJustExample_ApiService>("apiservice");

builder.AddProject<Projects.KluskaJustExample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
