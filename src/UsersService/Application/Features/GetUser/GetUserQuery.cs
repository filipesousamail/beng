using beng.user.service.Application.Features.GetUserDetails;
using beng.UsersService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace beng.UsersService.Application.Features.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<GetUserResponse?>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse?>
{
    private readonly AppDbContext _db;

    public GetUserQueryHandler(AppDbContext db)
    {
        this._db = db;
    }

    public async Task<GetUserResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var dbUser = await _db.Users.FirstOrDefaultAsync(e => e.Id == request.UserId);
        if (dbUser is null) return null;

        return new GetUserResponse
        {
            Id = dbUser.Id,
            Name = dbUser.Name
        };
    }
}