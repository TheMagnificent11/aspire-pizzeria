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

using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<PizzeriaDbContext>();

    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        try
        {
            var canConnect = await dbContext.Database.CanConnectAsync(cancellationTokenSource.Token);
            if (!canConnect)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationTokenSource.Token);
                continue;
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
