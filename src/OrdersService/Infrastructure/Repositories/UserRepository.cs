using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Guid> CreateUserAsync(User user)
    {
        var dbUser = await _db.Users.FirstOrDefaultAsync(e => e.Name.Equals(user.Name));
        if (dbUser is not null) return dbUser.Id;

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return user.Id;
    }
}