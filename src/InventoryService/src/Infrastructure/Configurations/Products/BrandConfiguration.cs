using beng.InventoryService.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Products;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(nameof(Brand), Schemas.PRODUCT);
        builder.Property(e => e.Name).IsRequired();
    }
}