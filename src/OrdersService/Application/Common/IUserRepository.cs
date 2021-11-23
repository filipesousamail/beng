using beng.OrdersService.Domain;

namespace beng.OrdersService.Application.Common;

public interface IUserRepository
{
    Task<Guid> CreateUserAsync(User user);
}