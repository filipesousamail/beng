namespace beng.InventoryService.Domain;

public class Status : Entity<Guid>
{
    public Status() => Id = new Guid();

    public string Name { get; set; }
}