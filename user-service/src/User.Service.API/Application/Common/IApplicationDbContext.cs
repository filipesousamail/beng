using Microsoft.EntityFrameworkCore;

namespace beng.user.service.Application.Common;

public interface IApplicationDbContext{
    DbSet<Domain.User> Users { get; set; }
}
