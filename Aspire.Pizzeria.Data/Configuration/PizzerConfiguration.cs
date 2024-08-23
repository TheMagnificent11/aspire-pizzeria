using Aspire.Pizzeria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspire.Pizzeria.Data.Configuration;

internal class PizzerConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Pizza.FieldLengths.Name);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(Pizza.FieldLengths.Description);
    }
}
