using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.InventoryService.Api.IntegrationEventHandlers;

[ApiController]
[Route("integrations/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpPost("product-created")]
    public async Task<IActionResult> ProductCreated([FromBody] ProductCreated request)
    {
        throw new NotImplementedException();
    }
}