using beng.UsersService.Application.Common;
using beng.UsersService.Domain;
using Contracts;
using Dapr.Client;
using MediatR;

namespace beng.UsersService.Application.Features.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repo;
    private readonly DaprClient _daprClient;

    public CreateUserCommandHandler(IUserRepository repo, DaprClient daprClient)
    {
        _repo = repo;
        _daprClient = daprClient;
    }

    [Transaction]
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = await _repo.CreateAsync(new User {Name = request.Name});

        var @event = new UserCreated {Id = userId, Name = request.Name};
        await _daprClient.PublishEventAsync("pubsub", nameof(UserCreated), @event, cancellationToken);

        return userId;
    }
}