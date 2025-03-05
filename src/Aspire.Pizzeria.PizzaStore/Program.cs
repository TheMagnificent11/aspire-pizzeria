using Aspire.Pizzeria.Common;
using Aspire.Pizzeria.Data;
using Aspire.Pizzeria.PizzaStore;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<PizzeriaDbContext>(ServiceNames.PizzaStoreDatabase);
builder.Services.AddTransient<PizzeriaSeeder>();

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.MigrateDatabaseAsync();

await app.RunAsync();
