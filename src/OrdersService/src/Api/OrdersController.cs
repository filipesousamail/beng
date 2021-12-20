using beng.OrdersService.Application.Features.Orders.GetOrder;
using beng.OrdersService.Application.Features.Orders.GetOrders;
using beng.OrdersService.Application.Features.Orders.PlaceOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Api;

[ApiController]
[Route("api/v2/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQueryRequest request) => 
        Ok(await _mediator.Send(request.ToQuery()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetOrderQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Place([FromBody] PlaceOrderCommandRequest request) => 
        Ok(await _mediator.Send(request.ToCommand()));
}