using System.Net.Sockets;
using Aspire.Pizzeria.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<PizzeriaDbContext>("pizza-store-database");
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

using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(3)))
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<PizzeriaDbContext>();
    var connectionString = dbContext.Database.GetConnectionString();
    var dbBuilder = new NpgsqlConnectionStringBuilder(connectionString);

    if (string.IsNullOrWhiteSpace(dbBuilder?.Host))
    {
        throw new InvalidOperationException("Failed to parse connection string.");
    }

    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        try
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(dbBuilder.Host, dbBuilder.Port);
            }

            await dbContext.Database.MigrateAsync(cancellationTokenSource.Token);

            var seeder = serviceScope.ServiceProvider.GetRequiredService<PizzeriaSeeder>();
            await seeder.SeedAsync(cancellationTokenSource.Token);

            break;
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "Failed to migrate database. Retrying in 5 seconds...");

            await Task.Delay(TimeSpan.FromSeconds(5), cancellationTokenSource.Token);
        }
    }
}

await app.RunAsync();
