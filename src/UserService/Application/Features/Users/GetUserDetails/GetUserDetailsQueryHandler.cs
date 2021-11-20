using beng.user.service.Application.Common;
using MediatR;

namespace beng.user.service.Application.Features.Users.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, Maybe<GetUserDetailsResponse>>
{
    private readonly IApplicationDbContext _db;

    public GetUserDetailsQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public Task<Maybe<GetUserDetailsResponse>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var userDetails = _db.Users.Where(e => e.Id == request.UserId)
            .Select(e => new GetUserDetailsResponse
            {
                Id = e.Id,
                Name = e.Name
            }).FirstOrDefault();

        return Task.FromResult(Maybe<GetUserDetailsResponse>.Of(userDetails));
    }
}