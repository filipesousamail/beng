namespace beng.InventoryService.Domain.Products;

public class Status : Entity<Guid>
{
    public Status() => Id = new Guid();

    public string Name { get; set; }
}