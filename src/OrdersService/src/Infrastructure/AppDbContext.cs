using System.Reflection;
using beng.OrdersService.Domain;
using beng.OrdersService.Domain.Orders;
using beng.OrdersService.Domain.Users;
using beng.OrdersService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OrderConfiguration)));
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
}