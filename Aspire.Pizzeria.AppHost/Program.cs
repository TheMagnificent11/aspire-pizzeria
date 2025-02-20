var builder = DistributedApplication.CreateBuilder(args);

var databaseServer = builder.AddPostgres("database-server");
var pizzaStoreDatabase = databaseServer.AddDatabase("pizza-store-database");

builder.AddProject<Projects.Aspire_Pizzeria_PizzaStore>("pizza-store")
    .WithReference(pizzaStoreDatabase);

var app = builder.Build();

await app.RunAsync();
