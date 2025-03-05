using Aspire.Pizzeria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aspire.Pizzeria.Data;

public sealed class PizzeriaDbContext : DbContext
{
    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pizza> Pizzas { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzeriaDbContext).Assembly);
    }
}
