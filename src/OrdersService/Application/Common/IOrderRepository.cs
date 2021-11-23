using beng.OrdersService.Domain;

namespace beng.OrdersService.Application.Common;

public interface IOrderRepository
{
    IPagedList<Order> GetOrdersAsync(string userName, decimal? orderTotalFrom, string orderBy,
        string orderDirection, int pageIndex = 0, int pageSize = 10);
}