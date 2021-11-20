using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.OrdersService.Application.Features.GetOrders;

public class GetOrdersQuery : IRequest<IPagedList<GetOrdersResponse>>
{
    public string UserName { get; set; }
    public string OrderBy { get; set; }
    public string OrderDirection { get; set; }
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}