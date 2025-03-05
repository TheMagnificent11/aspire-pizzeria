using Aspire.Pizzeria.Common;

var builder = DistributedApplication.CreateBuilder(args);

var databaseServer = builder.AddPostgres(ServiceNames.DatabaseServer)
    .WithDataVolume(isReadOnly: false);

var pizzaStoreDatabase = databaseServer.AddDatabase(ServiceNames.PizzaStoreDatabase);

builder.AddProject<Projects.Aspire_Pizzeria_PizzaStore>(ServiceNames.PizzaStore)
    .WithReference(pizzaStoreDatabase);

var app = builder.Build();

await app.RunAsync();
