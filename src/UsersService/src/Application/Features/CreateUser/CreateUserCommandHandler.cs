using beng.UsersService.Application.Common;
using beng.UsersService.Domain;
using beng.UsersService.Infrastructure;
using Contracts;
using Dapr.Client;
using MediatR;

namespace beng.UsersService.Application.Features.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly AppDbContext _db;
    private readonly DaprClient _daprClient;

    public CreateUserCommandHandler(AppDbContext db, DaprClient daprClient)
    {
        this._db = db;
        _daprClient = daprClient;
    }

    [Transaction]
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = _db.Users.FirstOrDefault(e => e.Name.Equals(request.Name));
        if (dbUser is not null) return dbUser.Id;

        var user = new User { Name = request.Name };

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();

        var @event = new UserCreated { Id = user.Id, Name = user.Name };
        await _daprClient.PublishEventAsync("pubsub", nameof(UserCreated), @event, cancellationToken);

        return user.Id;
    }
}