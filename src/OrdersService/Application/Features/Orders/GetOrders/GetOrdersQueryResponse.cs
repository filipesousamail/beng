using System.Linq.Expressions;
using beng.OrdersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Application.Features.Orders.GetOrders;

public class GetOrdersQueryResponse
{
    public decimal Total { get; set; }
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
}