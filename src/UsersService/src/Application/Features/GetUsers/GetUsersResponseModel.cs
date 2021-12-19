using System.Linq.Expressions;
using beng.UsersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace beng.UsersService.Application.Features.GetUsers;

public record GetUsersResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static Expression<Func<User, GetUsersResponseModel>> GetUserListResponseModelProjection => user =>
        new GetUsersResponseModel
        {
            Id = user.Id,
            Name = user.Name
        };
}

public static class GetUsersQueryExtensions
{
    public static IQueryable<User> ApplyGetListFilters(this DbSet<User> users, GetUsersQuery request)
    {
        var usersQuery = users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.UserName))
            usersQuery = usersQuery.Where(e => EF.Functions.Like(e.Name, $"{request.UserName}%"));

        return usersQuery;
    }
}