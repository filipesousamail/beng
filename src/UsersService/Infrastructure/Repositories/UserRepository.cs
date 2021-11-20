using beng.user.service.Application.Common;
using beng.user.service.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.user.service.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) => _db = db;

    public async Task<User> GetByIdAsync(Guid id) => await _db.Users.FirstOrDefaultAsync(e => e.Id == id);
}