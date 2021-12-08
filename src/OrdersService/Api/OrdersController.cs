using beng.OrdersService.Application.Features.Orders.GetOrders;
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
}