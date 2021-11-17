using System;

namespace beng.user.service.Application.Features.Users.GetUserDetails;

public record GetUserDetailsResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public static GetUserDetailsResponse? Of(beng.user.service.Domain.User user){
        if (user is null) return null;

            return new GetUserDetailsResponse
            {
                Id = user.Id,
                Name = user.Name
            };
    }
}
