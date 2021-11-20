using beng.OrdersService.Application.Features.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Application.Features;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public IActionResult GetOrders(GetOrdersQuery request) => Ok(_mediator.Send(request));
}