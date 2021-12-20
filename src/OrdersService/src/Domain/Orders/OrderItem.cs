namespace beng.OrdersService.Domain.Orders;

public class OrderItem : Entity<Guid>
{
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}