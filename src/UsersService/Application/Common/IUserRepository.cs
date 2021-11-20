using beng.user.service.Domain;

namespace beng.user.service.Application.Common;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
}