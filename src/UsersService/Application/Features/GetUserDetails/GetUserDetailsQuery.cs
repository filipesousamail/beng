using MediatR;

namespace beng.user.service.Application.Features.GetUserDetails;

public class GetUserDetailsQuery : IRequest<GetUserDetailsResponse>
{
    public GetUserDetailsQuery(Guid id)
    {
        UserId = id;
    }

    public Guid UserId { get; set; }
}