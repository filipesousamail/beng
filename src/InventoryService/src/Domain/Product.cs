namespace beng.InventoryService.Domain;

public class Product : AggregateRoot<Guid>
{
    public Product() => Id = new Guid();

    public string Name { get; set; }
    
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
    public Guid ColorId { get; set; }
    public Color Color { get; set; }
    public Guid StatusId { get; set; }
    public Status Status { get; set; }
}