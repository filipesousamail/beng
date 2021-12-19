using MediatR;

namespace beng.UsersService.Application.Features.CreateUser;

public record CreateUserCommand(string Name) : IRequest<Guid>;