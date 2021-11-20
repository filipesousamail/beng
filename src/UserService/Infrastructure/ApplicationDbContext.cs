using beng.user.service.Application.Common;
using beng.user.service.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.user.service.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}