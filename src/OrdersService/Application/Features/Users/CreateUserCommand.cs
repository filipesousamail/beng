using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using MediatR;

namespace beng.OrdersService.Application.Features.Users;

public record CreateUserCommand(string Name) : IRequest<Guid>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repo;

    public CreateUserCommandHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken) =>
        await _repo.CreateUserAsync(new User {Name = request.Name});
}