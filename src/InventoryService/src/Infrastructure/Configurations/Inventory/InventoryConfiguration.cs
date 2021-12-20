using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Inventory;

public class InventoryConfiguration:IEntityTypeConfiguration<Domain.Inventory.Inventory>
{
    public void Configure(EntityTypeBuilder<Domain.Inventory.Inventory> builder)
    {
        builder.ToTable(nameof(Domain.Inventory.Inventory), Schemas.INVENTORY);
        builder.Property(e => e.Qty).IsRequired();
        builder.Property(e => e.Sku).IsRequired();
    }
}