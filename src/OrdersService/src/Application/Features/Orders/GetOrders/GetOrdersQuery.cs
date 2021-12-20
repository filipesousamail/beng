using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public record GetOrdersQuery : IRequest<PagedList<GetOrdersQueryResponse>>
{
    public string? UserName { get; set; }
    public decimal? OrderTotalFrom { get; set; }
    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;
}