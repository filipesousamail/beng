using beng.OrdersService.Application.Common;
using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IPagedList<GetOrdersResponse>>
{
    private readonly IOrderRepository _repo;
    private readonly IGetOrdersQueryMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository repo, IGetOrdersQueryMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public Task<IPagedList<GetOrdersResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = _repo.GetOrdersAsync(request.UserName, request.OrderTotalFrom, request.OrderBy,
            request.OrderDirection, request.PageIndex, request.PageSize);

        return Task.FromResult(_mapper.PagedOrderResponseOf(orders));
    }
}