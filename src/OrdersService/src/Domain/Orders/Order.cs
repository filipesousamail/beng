namespace beng.OrdersService.Domain.Orders;

public class Order : AggregateRoot<Guid>
{
    public Order() => Id = Guid.NewGuid();

    public decimal Total => OrderItems.Sum(e => e.Total);
    public int Quantity => OrderItems.Sum(e => e.Quantity);

    public Guid UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}