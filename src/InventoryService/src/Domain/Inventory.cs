namespace beng.InventoryService.Domain;

public class Inventory : AggregateRoot<Guid>
{
    public Inventory()
    {
        Id = Guid.NewGuid();
        Sku = Nanoid.Nanoid.Generate("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", 16);
    }

    public string Sku { get; private set; }
    public double Qty { get; set; }

    public Guid ProductId { get; set; }
    public Guid StockUnitId { get; set; }
    public StockUnit StockUnit { get; set; }
}