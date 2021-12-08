using beng.OrdersService.Application.Common;
using beng.OrdersService.Infrastructure;
using System.Linq.Dynamic.Core;
using MediatR;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IPagedResult<GetOrdersQueryResponse>>
{
    private readonly AppDbContext _db;
    private readonly IOrderRepository _repo;
    private readonly Dictionary<string, string> _validOrderSubjects =
            new(StringComparer.OrdinalIgnoreCase) { { "Id", "Id" }, { "Total", "Total" }, { "UserName", "UserName" } };

    public GetOrdersQueryHandler(AppDbContext db, IOrderRepository repo)
    {
        _db = db;
        _repo = repo;
    }

    public async Task<IPagedResult<GetOrdersQueryResponse>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        _validOrderSubjects.TryGetValue(request.OrderBy ?? string.Empty, out var curatedOrderBy);
        curatedOrderBy ??= nameof(v1.GetOrdersQueryResponse.UserId);

        var orders = _db.Orders
            .ApplyGetOrdersQueryFilters(request)
            .Select(GetOrdersQueryResponse.Projection())
            .OrderBy($"{curatedOrderBy} {request.OrderDirection ?? "asc"}")
            .TakePage(request.PageIndex, request.PageSize);

        return orders;
    }
}

