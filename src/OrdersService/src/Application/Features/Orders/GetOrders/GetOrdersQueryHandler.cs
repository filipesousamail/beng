using beng.OrdersService.Application.Common;
using beng.OrdersService.Infrastructure;
using System.Linq.Dynamic.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PagedList<GetOrdersQueryResponse>>
{
    private readonly AppDbContext _db;
    private readonly Dictionary<string, string> _validOrderSubjects =
            new(StringComparer.OrdinalIgnoreCase) { { "Id", "Id" }, { "Total", "Total" }, { "UserName", "UserName" } };

    public GetOrdersQueryHandler(AppDbContext db) => _db = db;

    public async Task<Common.PagedList<GetOrdersQueryResponse>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        _validOrderSubjects.TryGetValue(request.OrderBy ?? string.Empty, out var curatedOrderBy);
        curatedOrderBy ??= nameof(v1.GetOrdersQueryResponse.UserId);

        var ordersQuery =
            from order in _db.Orders
            join user in _db.Users on order.UserId equals user.Id
            select new { order, user };

        if (!string.IsNullOrWhiteSpace(request.UserName))
            ordersQuery = ordersQuery.Where(e => EF.Functions.Like(e.user.Name, $"{request.UserName}%"));

        if (request.OrderTotalFrom.HasValue)
            ordersQuery = ordersQuery.Where(e => e.order.Total >= request.OrderTotalFrom);

        var orders = ordersQuery
            .Select(e =>
                new GetOrdersQueryResponse
                {
                    Total = e.order.Total,
                    UserId = e.order.UserId,
                    UserName = e.user.Name
                })
            .OrderBy($"{curatedOrderBy} {request.OrderDirection ?? "asc"}")
            .TakePage(request.PageIndex, request.PageSize);

        return orders;
    }
}

