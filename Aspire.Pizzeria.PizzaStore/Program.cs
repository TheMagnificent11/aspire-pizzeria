using Aspire.Pizzeria.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerDbContext<PizzeriaDbContext>("sql-database");
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

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<PizzeriaDbContext>();
    await dbContext.Database.MigrateAsync();

    var seeder = serviceScope.ServiceProvider.GetRequiredService<PizzeriaSeeder>();
    await seeder.SeedAsync();
}

await app.RunAsync();
