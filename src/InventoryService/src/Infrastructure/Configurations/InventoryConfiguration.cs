using beng.InventoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations;

public class InventoryConfiguration:IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.Property(e => e.Qty).IsRequired();
        builder.Property(e => e.Sku).IsRequired();
    }
}