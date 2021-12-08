using beng.OrdersService.Application.Features.Orders.GetOrders.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Api.v1;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Obsolete("Use v2")]public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery request) =>
        Ok(await _mediator.Send(request));
}