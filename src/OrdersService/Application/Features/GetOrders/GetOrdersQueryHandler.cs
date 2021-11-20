using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.OrdersService.Application.Features.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IPagedList<GetOrdersResponse>>
{
    private readonly IOrderRepository _repo;

    public GetOrdersQueryHandler(IOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<IPagedList<GetOrdersResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repo.GetOrdersAsync(request.UserName, request.OrderBy, request.OrderDirection,
            request.PageIndex, request.PageSize);

        return orders.Select(e => new GetOrdersResponse()
        {
            Total = e.Total,
            UserId = e.UserId,
            UserName = e.User.Name,
        }).TakePage(request.PageIndex, request.PageSize);
    }
}