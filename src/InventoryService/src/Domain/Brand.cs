namespace beng.InventoryService.Domain;

public class Brand : Entity<Guid>
{
    public Brand() => Id = Guid.NewGuid();

    public string Name { get; set; }
}