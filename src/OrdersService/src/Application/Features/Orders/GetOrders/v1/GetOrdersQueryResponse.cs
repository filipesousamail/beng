using System.Linq.Expressions;
using beng.OrdersService.Domain;
using beng.OrdersService.Domain.Orders;
using beng.OrdersService.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Application.Features.Orders.GetOrders.v1;

public class GetOrdersQueryResponse
{
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public Guid UserId { get; set; }
    public string? UserName { get; set; }

    public static Expression<Func<Order, GetOrdersQueryResponse>> Projection(List<User> userList) => order =>
        new GetOrdersQueryResponse
        {
            Total = order.Total,
            Quantity = order.Quantity,
            UserId = order.UserId,
            UserName = GetUserName(userList, order.UserId)
        };

    private static string? GetUserName(IEnumerable<User> userList, Guid userId) =>
        userList.FirstOrDefault(u => u.Id == userId)?.Name;
}

public static class GetOrdersQueryExtensions
{
    public static IQueryable<Order> ApplyGetOrdersQueryFilters(this DbSet<Order> source, GetOrdersQuery request,
        List<Guid> userIds)
    {
        var ordersQuery = source.AsQueryable();

        if (userIds.Any())
            ordersQuery = ordersQuery.Where(e => userIds.Contains(e.UserId));

        if (request.OrderTotalFrom.HasValue)
            ordersQuery = ordersQuery.Where(e => e.Total >= request.OrderTotalFrom);

        return ordersQuery;
    }
}
