using Aspire.Pizzeria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspire.Pizzeria.Data.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.CustomerName)
            .IsRequired()
            .HasMaxLength(Order.FieldLengths.CustomerName);

        builder
            .Property(x => x.DeliveryAddress)
            .IsRequired()
            .HasMaxLength(Order.FieldLengths.DeliveryAddress);

        builder
            .HasMany(o => o.Pizzas)
            .WithOne(op => op.Order)
            .HasForeignKey(op => op.PizzaId);

        builder
            .HasMany(o => o.Pizzas)
            .WithOne(op => op.Order)
            .HasForeignKey(op => op.OrderId);
    }
}
