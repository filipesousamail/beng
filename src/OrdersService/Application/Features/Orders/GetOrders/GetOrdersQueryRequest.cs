namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public record GetOrdersQueryRequest
{
    public string? UserName { get; set; }
    public decimal? OrderTotalFrom { get; set; }
    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;

    internal GetOrdersQuery ToQuery() =>
    new()
    {
        OrderBy = OrderBy,
        OrderDirection = OrderDirection,
        OrderTotalFrom = OrderTotalFrom,
        PageIndex = PageIndex,
        PageSize = PageSize,
        UserName = UserName
    };
}
