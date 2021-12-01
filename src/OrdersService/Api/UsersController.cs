using beng.OrdersService.Application.Features.Users;
using Contracts;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Api;

[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Topic("pubsub", nameof(UserCreated))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreated user)
    {
        var cenas = user as UserCreated;
        cenas.Name = null; // validation behaviour not raising errors?...
        var userId = await _mediator.Send(new CreateUserCommand(cenas));

        return Accepted(userId);
    }
}