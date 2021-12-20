using FluentValidation;

namespace beng.OrdersService.Application.Features.Orders.PlaceOrder;

public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        RuleFor(e => e.OrderItems).NotEmpty();
        RuleFor(e => e.UserId).NotEmpty();
    }
}