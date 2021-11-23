using beng.user.service.Application.Features.GetUserDetails;
using beng.UsersService.Application.Common;
using MediatR;

namespace beng.UsersService.Application.Features.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<GetUserResponse?>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse?>
{
    private readonly IUserRepository _repo;

    public GetUserQueryHandler(IUserRepository repo) => _repo = repo;

    public async Task<GetUserResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var dbUser = await _repo.GetByIdAsync(request.UserId);
        if (dbUser is null) return null;

        return new GetUserResponse
        {
            Id = dbUser.Id,
            Name = dbUser.Name
        };
    }
}