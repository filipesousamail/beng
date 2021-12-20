namespace beng.InventoryService.Domain.Products;

public class Color : Entity<Guid>
{
    public Color() => Id = Guid.NewGuid();

    public string Name { get; set; }
}