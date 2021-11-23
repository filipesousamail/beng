using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public interface IGetOrdersQueryMapper
{
    IPagedList<GetOrdersResponse> PagedOrderResponseOf(IPagedList<Order> orders);
}

public class GetOrdersQueryMapper : IGetOrdersQueryMapper
{
    public IPagedList<GetOrdersResponse> PagedOrderResponseOf(IPagedList<Order> pagedOrders) =>
        pagedOrders.Items.Select(e => new GetOrdersResponse
        {
            Total = e.Total,
            UserId = e.UserId,
            UserName = e.User.Name,
        }).TakePage(pagedOrders.PageIndex, pagedOrders.PageSize);
}