using beng.InventoryService.Application.Features.GetAllProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.InventoryService.Application.Api;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest request) => 
        Ok(await _mediator.Send(request.ToQuery()));
}