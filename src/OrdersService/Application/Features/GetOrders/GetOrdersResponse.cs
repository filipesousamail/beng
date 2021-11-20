namespace beng.OrdersService.Application.Features.GetOrders;

public class GetOrdersResponse
{
    public decimal Total { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}