using beng.UsersService.Domain;

namespace beng.UsersService.Application.Common;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(User user);
}