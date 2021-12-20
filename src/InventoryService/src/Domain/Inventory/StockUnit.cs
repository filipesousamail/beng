namespace beng.InventoryService.Domain.Inventory;

public class StockUnit : Entity<Guid>
{
    public StockUnit() => Id = Guid.NewGuid();
    
    public string Name { get; set; }
}