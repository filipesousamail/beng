using beng.OrdersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
}