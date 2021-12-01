using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using beng.OrdersService.Infrastructure;
using MediatR;
using System.Linq.Dynamic.Core;

namespace beng.OrdersService.Application.Features.Orders.GetOrders
{
    public class GetOrdersQueryHandler :
        IRequestHandler<GetOrdersQuery, IPagedList<GetOrdersQueryResponse>>
    {
        private readonly AppDbContext _db;
        private readonly IOrderRepository _repo;
        private readonly IUserServiceGateway _userServiceGateway;
        private readonly HashSet<string> _validOrderSubjects = new() {"Id", "Total"};

        public GetOrdersQueryHandler(
            AppDbContext db,
            IOrderRepository repo,
            IUserServiceGateway userServiceGateway)
        {
            _db = db;
            _repo = repo;
            _userServiceGateway = userServiceGateway;
        }

        public async Task<IPagedList<GetOrdersQueryResponse>> Handle(GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userServiceGateway.GetUsersAsync(request.UserName, request.OrderBy,
                request.OrderDirection, request.PageIndex, request.PageSize, cancellationToken);

            var curatedOrderBy = _validOrderSubjects.Contains(request.OrderBy)
                ? request.OrderBy
                : nameof(GetOrdersQueryResponse.Total);
            var userList = users.ToList();
            
            var orders = _db.Orders
                .ApplyGetOrdersQueryFilters(request, userList.Select(e => e.Id).ToList())
                .Select(GetOrdersQueryResponse.Projection(userList))
                .OrderBy($"{curatedOrderBy} {request.OrderDirection ?? "asc"}")
                .TakePage(request.PageIndex, request.PageSize);

            return orders;
        }
    }
}