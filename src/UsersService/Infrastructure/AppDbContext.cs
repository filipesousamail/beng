using System.Reflection;
using beng.UsersService.Domain;
using beng.UsersService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace beng.UsersService.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserConfiguration)));
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
}