using System.Linq.Dynamic.Core;
using beng.UsersService.Application.Common;
using beng.UsersService.Infrastructure;
using MediatR;

namespace beng.UsersService.Application.Features.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IPagedList<GetUsersResponseModel>>
{
    private readonly AppDbContext _db;

    public GetUsersQueryHandler(AppDbContext db)
    {
        _db = db;
    }

    public Task<IPagedList<GetUsersResponseModel>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = _db.Users
            .ApplyGetListFilters(request)
            .Select(GetUsersResponseModel.GetUserListResponseModelProjection)
            .OrderBy($"{request.OrderBy ?? "Id"} {request.OrderDirection ?? "asc"}")
            .TakePage(request.PageIndex, request.PageSize);

        return Task.FromResult(users);
    }
}