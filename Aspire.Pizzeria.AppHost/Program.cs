var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sql-server");
var sqlDatabase = sqlServer.AddDatabase("sql-database");

builder.AddProject<Projects.Aspire_Pizzeria_PizzaStore>("pizza-store")
    .WithReference(sqlDatabase);

var app = builder.Build();

await app.RunAsync();
