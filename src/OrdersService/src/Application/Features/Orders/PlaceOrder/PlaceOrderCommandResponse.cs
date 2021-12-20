namespace beng.OrdersService.Application.Features.Orders.PlaceOrder;

public record PlaceOrderCommandResponse
{
    public Guid OrderId { get; set; }
    public decimal Total => OrderItems.Sum(e => e.Total);
    public int Quantity => OrderItems.Sum(e => e.Quantity);
    public Guid UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();

    public record OrderItem
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Guid ProductId { get; set; }
    }
}