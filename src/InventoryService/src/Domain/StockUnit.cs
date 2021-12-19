namespace beng.InventoryService.Domain;

public class StockUnit : Entity<Guid>
{
    public StockUnit() => Id = Guid.NewGuid();
    
    public string Name { get; set; }
}