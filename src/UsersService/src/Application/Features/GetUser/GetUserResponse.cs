using beng.UsersService.Domain;

namespace beng.user.service.Application.Features.GetUserDetails;

public record GetUserResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public static GetUserResponse? Of(User user){
        if (user is null) return null;

            return new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name
            };
    }
}
