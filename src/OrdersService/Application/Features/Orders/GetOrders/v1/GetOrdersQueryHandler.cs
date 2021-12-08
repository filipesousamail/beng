using beng.OrdersService.Application.Common;
using beng.OrdersService.Infrastructure;
using MediatR;
using System.Linq.Dynamic.Core;

namespace beng.OrdersService.Application.Features.Orders.GetOrders.v1;

public class GetOrdersQueryHandler :
    IRequestHandler<GetOrdersQuery, IPagedResult<GetOrdersQueryResponse>>
{
    private readonly AppDbContext _db;
    private readonly IOrderRepository _repo;
    private readonly IUserServiceGateway _userServiceGateway;
    private readonly Dictionary<string, string> _validOrderSubjects =
        new(StringComparer.OrdinalIgnoreCase) { { "Id", "Id" }, { "Total", "Total" }, { "UserName", "Name" } };

    public GetOrdersQueryHandler(
        AppDbContext db,
        IOrderRepository repo,
        IUserServiceGateway userServiceGateway)
    {
        _db = db;
        _repo = repo;
        _userServiceGateway = userServiceGateway;
    }

    public async Task<IPagedResult<GetOrdersQueryResponse>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        _validOrderSubjects.TryGetValue(request.OrderBy ?? string.Empty, out var curatedOrderBy);
        curatedOrderBy ??= nameof(GetOrdersQueryResponse.Total);

        var users = await _userServiceGateway.GetUsersAsync(request.UserName, request.OrderBy,
            request.OrderDirection, request.PageIndex, request.PageSize, cancellationToken);

        var userList = users.ToList();

        var orders = _db.Orders // TODO: test this projection to see user name
            .ApplyGetOrdersQueryFilters(request, userList.Select(e => e.Id).ToList())
            .Select(GetOrdersQueryResponse.Projection(userList))
            .OrderBy($"{curatedOrderBy} {request.OrderDirection ?? "asc"}")
            .TakePage(request.PageIndex, request.PageSize);

        return orders;
    }
}
