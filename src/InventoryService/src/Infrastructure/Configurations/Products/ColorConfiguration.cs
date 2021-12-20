using beng.InventoryService.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Products;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable(nameof(Color), Schemas.PRODUCT);
        builder.Property(e => e.Name).IsRequired();
    }
}