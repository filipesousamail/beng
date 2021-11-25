using beng.OrdersService.Application.Features.Users;
using Contracts;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Api.IntegrationEventConsumers;

[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Topic("pubsub", "UserCreated")]
    [HttpPost("UserCreated")]
    public async Task<IActionResult> Create(UserCreated cenas)
    {
        // var userCreated = cenas as UserCreated;
        await _mediator.Send(new CreateUserCommand(cenas.Name));

        return Accepted();
    }
}