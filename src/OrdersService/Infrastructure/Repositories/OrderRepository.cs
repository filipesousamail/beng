using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public OrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(string userName, string orderBy, string orderDirection,
        int pageIndex, int pageSize = 10)
    {
        var orderQuery = _db.Orders
            .OrderBy($"{orderBy ?? "Id"} {orderDirection ?? "asc"}")
            .Take(pageIndex..pageSize);

        if (string.IsNullOrWhiteSpace(userName)) return await orderQuery.ToListAsync();

        var userIds = _httpClient.get(userName);

        orderQuery = orderQuery.Where(e => userIds.Contains(e.UserId));

        return await orderQuery.ToListAsync();
    }
}