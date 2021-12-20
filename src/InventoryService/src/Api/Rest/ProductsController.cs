using beng.InventoryService.Application.Features.CreateProduct;
using beng.InventoryService.Application.Features.GetAllProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.InventoryService.Api.Rest;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest request) => 
        Ok(await _mediator.Send(request.ToQuery()));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request) => 
        CreatedAtRoute(string.Empty, await _mediator.Send(request.ToCommand()));
}