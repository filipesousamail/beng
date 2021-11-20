using beng.user.service.Application.Common;
using MediatR;

namespace beng.user.service.Application.Features.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResponse>
{
    private readonly IUserRepository _repo;

    public GetUserDetailsQueryHandler(IUserRepository repo) => _repo = repo;

    public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var dbUser = await _repo.GetByIdAsync(request.UserId);
        if (dbUser is null) return null;

        return new GetUserDetailsResponse
        {
            Id = dbUser.Id,
            Name = dbUser.Name
        };
    }
}