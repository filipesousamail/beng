namespace beng.OrdersService.Domain;

public class Order : Entity<Guid>
{
    public Order() => Id = Guid.NewGuid();

    public decimal Total { get; set; }
    public int Quantity { get; set; }

    public Guid UserId { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}