using FluentValidation;

namespace beng.OrdersService.Application.Features.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
    }
}