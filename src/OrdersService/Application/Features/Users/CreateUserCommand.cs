using beng.OrdersService.Application.Common;
using beng.OrdersService.Domain;
using Contracts;
using FluentValidation;
using MediatR;

namespace beng.OrdersService.Application.Features.Users;

public record CreateUserCommand : IRequest<Guid>
{
    public CreateUserCommand(UserCreated userCreated)
    {
        Id = userCreated.Id;
        Name = userCreated.Name;
    }

    public Guid Id { get; }
    public string Name { get; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repo;

    public CreateUserCommandHandler(IUserRepository repo) => _repo = repo;

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken) =>
        await _repo.CreateUserAsync(new User {Id = request.Id, Name = request.Name});
}

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.Name).NotEmpty();
    }
}