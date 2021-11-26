namespace beng.OrdersService.Application.Features.Orders.GetOrdersWithUserDependency
{
    public class GetOrdersWithUserDependencyResponse
    {
        public decimal Total { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}