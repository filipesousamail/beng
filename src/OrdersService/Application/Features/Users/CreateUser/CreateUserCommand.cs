using beng.OrdersService.Domain;
using beng.OrdersService.Infrastructure;
using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace beng.OrdersService.Application.Features.Users.CreateUser;

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
    private readonly AppDbContext _db;

    public CreateUserCommandHandler(AppDbContext db) => _db = db;

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _db.Users.FirstOrDefaultAsync(e => e.Name.Equals(request.Name));
        if (dbUser is not null) return request.Id;

        _db.Users.Add(new User { Id = request.Id, Name = request.Name });
        await _db.SaveChangesAsync();

        return request.Id;
    }
}

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.Name).NotEmpty();
    }
}