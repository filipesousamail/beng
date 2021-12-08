using System.Linq.Expressions;
using beng.OrdersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public class GetOrdersQueryResponse
{
    public decimal Total { get; set; }
    public Guid UserId { get; set; }
    public string? UserName { get; set; }

    public static Expression<Func<Order, GetOrdersQueryResponse>> Projection() => order =>
        new GetOrdersQueryResponse
        {
            Total = order.Total,
            UserId = order.UserId,
            UserName = order.User.Name
        };
}

public static class GetOrdersQueryExtensions
{
    public static IQueryable<Order> ApplyGetOrdersQueryFilters(this DbSet<Order> source, GetOrdersQuery request)
    {
        var ordersQuery = source.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.UserName))
            ordersQuery = ordersQuery.Where(e => EF.Functions.Like(e.User.Name, $"{request.UserName}%"));

        if (request.OrderTotalFrom.HasValue)
            ordersQuery = ordersQuery.Where(e => e.Total >= request.OrderTotalFrom);

        return ordersQuery;
    }
}