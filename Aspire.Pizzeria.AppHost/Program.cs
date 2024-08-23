var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aspire_Pizzeria_PizzaStore>("pizza-store");

var app = builder.Build();

await app.RunAsync();
