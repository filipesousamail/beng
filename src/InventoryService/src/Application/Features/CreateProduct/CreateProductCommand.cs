using System.Data;
using MediatR;

namespace beng.InventoryService.Application.Features.CreateProduct;

public record CreateProductCommand : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
}