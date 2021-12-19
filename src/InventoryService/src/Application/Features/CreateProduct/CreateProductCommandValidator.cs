using FluentValidation;

namespace beng.InventoryService.Application.Features.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
    }
}