using beng.UsersService.Application.Features.GetUsers;

namespace beng.UsersService.Api.Models;

public record GetUsersRequestModel(string? UserName, string? OrderBy, string? OrderDirection = "asc", int PageIndex = 0,
    int PageSize = 10)
{
    public GetUsersQuery AsGetUserListQuery() =>
        new()
        {
            UserName = UserName,
            OrderBy = OrderBy,
            OrderDirection = OrderDirection,
            PageSize = PageSize,
            PageIndex = PageIndex
        };
}