using beng.UsersService.Application.Common;
using MediatR;

namespace beng.UsersService.Application.Features.GetUsers;

public class GetUsersQuery : IRequest<PagedList<GetUsersResponseModel>>
{
    public string UserName { get; set; }
    public string OrderBy { get; set; }
    public string OrderDirection { get; set; }
    public int PageSize { get; set; } = 10;
    public int PageIndex { get; set; }
}