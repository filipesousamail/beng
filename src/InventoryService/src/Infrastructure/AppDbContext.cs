using System.Reflection;
using beng.InventoryService.Domain;
using beng.InventoryService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace beng.InventoryService.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProductConfiguration)));
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
}