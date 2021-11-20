using beng.OrdersService.Domain;

namespace beng.OrdersService.Application.Common;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync(string userName, string orderBy, string orderDirection, int pageIndex,
        int pageSize);
}