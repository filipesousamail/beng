using beng.InventoryService.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), Schemas.PRODUCT);
        builder.Property(e => e.Name).IsRequired();
    }
}