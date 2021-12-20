using beng.InventoryService.Domain.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Inventory;

public class StockUnitConfiguration:IEntityTypeConfiguration<StockUnit>
{
    public void Configure(EntityTypeBuilder<StockUnit> builder)
    {
        builder.ToTable(nameof(StockUnit), Schemas.INVENTORY);
        builder.Property(e => e.Name).IsRequired();
    }
}