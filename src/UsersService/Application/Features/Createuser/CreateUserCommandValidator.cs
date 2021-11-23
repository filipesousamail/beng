using FluentValidation;

namespace beng.UsersService.Application.Features.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
    }
}