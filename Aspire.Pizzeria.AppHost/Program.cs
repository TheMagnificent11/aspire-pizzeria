var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aspire_Pizzeria_ApiService>("api-service");

var app = builder.Build();

await app.RunAsync();
