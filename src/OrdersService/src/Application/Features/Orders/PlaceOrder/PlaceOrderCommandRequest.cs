
namespace beng.OrdersService.Application.Features.Orders.PlaceOrder;

public record PlaceOrderCommandRequest
{
    public Guid UserId { get; init; }
    public List<OrderItem> OrderItems { get; init; } = new();

    public record OrderItem
    {
        public int Quantity { get; init; }
        public decimal Total { get; init; }
        public Guid ProductId { get; init; }
    }

    public PlaceOrderCommand ToCommand() =>
        new()
        {
            OrderItems = OrderItems.Select(e => new PlaceOrderCommand.OrderItem
            {
                Quantity = e.Quantity,
                Total = e.Total,
                ProductId = e.ProductId
            }).ToList(),
            UserId = UserId
        };
}