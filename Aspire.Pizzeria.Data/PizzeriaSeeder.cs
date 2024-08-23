using Aspire.Pizzeria.Domain;

namespace Aspire.Pizzeria.Data;

public sealed class PizzeriaSeeder
{
    private readonly PizzeriaDbContext dbContext;

    public PizzeriaSeeder(PizzeriaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        await this.dbContext.Database.EnsureCreatedAsync();

        var pizzas = Menu.Pizzas;
        var hasChanges = false;

        foreach (var item in pizzas)
        {
            var existing = await this.dbContext.Pizzas.FindAsync(item.Id);

            if (existing == null)
            {
                this.dbContext.Pizzas.Add(item);
                hasChanges = true;
            }
        }

        if (!hasChanges)
        {
            return;
        }

        await this.dbContext.SaveChangesAsync();
    }
}
