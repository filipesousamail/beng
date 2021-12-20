using MediatR;

namespace beng.OrdersService.Application.Features.Orders.PlaceOrder;

public record PlaceOrderCommand : IRequest<PlaceOrderCommandResponse>
{
    public Guid UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();

    public record OrderItem
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Guid ProductId { get; set; }
    }
}