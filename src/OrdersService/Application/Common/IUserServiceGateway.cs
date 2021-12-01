using beng.OrdersService.Domain;

namespace beng.OrdersService.Application.Common;

public interface IUserServiceGateway
{
    Task<IEnumerable<User>> GetUsersAsync(string userName, string orderBy, string orderDirection, int pageIndex = 0,
        int pageSize = 10, CancellationToken cancellationToken = default);
}