namespace beng.InventoryService.Domain;

public class Color : Entity<Guid>
{
    public Color() => Id = Guid.NewGuid();

    public string Name { get; set; }
}