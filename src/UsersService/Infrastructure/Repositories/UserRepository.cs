using beng.UsersService.Application.Common;
using beng.UsersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.UsersService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) => _db = db;

    public async Task<User?> GetByIdAsync(Guid id) => await _db.Users.FirstOrDefaultAsync(e => e.Id == id);
    
    public async Task<Guid> CreateAsync(User user)
    {
        var dbUser = _db.Users.FirstOrDefault(e => e.Name.Equals(user.Name));
        if (dbUser is not null) return dbUser.Id;

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();

        return user.Id;
    }
}