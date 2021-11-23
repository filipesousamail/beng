using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using System.Linq.Dynamic.Core;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public OrderRepository(AppDbContext db) => _db = db;

    public IPagedList<Order> GetOrdersAsync(string userName, decimal? orderTotalFrom, string orderBy,
        string orderDirection, int pageIndex = 0, int pageSize = 10)
    {
        var treatedOrderBy = string.IsNullOrWhiteSpace(orderBy) ? "Id" : orderBy;
        var treatedOrderDirection = string.IsNullOrWhiteSpace(orderDirection) ? "asc" : orderDirection;
        var orderQuery = _db.Orders.Include(e => e.User).AsQueryable();

        if (orderTotalFrom.HasValue)
            orderQuery = orderQuery.Where(e => e.Total >= orderTotalFrom);

        if (!string.IsNullOrWhiteSpace(userName))
            orderQuery = orderQuery.Where(e => e.User.Name.Contains(userName));

        return orderQuery.OrderBy(e => $"{treatedOrderBy} {treatedOrderDirection}").TakePage(pageIndex, pageSize);
    }
}