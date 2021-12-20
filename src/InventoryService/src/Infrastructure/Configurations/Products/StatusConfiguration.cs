using beng.InventoryService.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace beng.InventoryService.Infrastructure.Configurations.Products;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable(nameof(Status), Schemas.PRODUCT);
        builder.Property(e => e.Name).IsRequired();
    }
}