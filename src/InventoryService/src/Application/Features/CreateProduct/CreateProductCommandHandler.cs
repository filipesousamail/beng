using MediatR;

namespace beng.InventoryService.Application.Features.CreateProduct;

public record CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        // await _mediatr.Publish(new ProductCreated()); // bus publish...
    }
}