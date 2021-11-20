using beng.user.service.Application.Common;
using MediatR;

namespace beng.user.service.Application.Features.Users.GetUserDetails;

public class GetUserDetailsQuery : IRequest<Maybe<GetUserDetailsResponse>>
{
    public GetUserDetailsQuery(Guid id)
    {
        UserId = id;
    }

    public Guid UserId { get; set; }
}