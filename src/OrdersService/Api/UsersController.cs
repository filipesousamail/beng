using beng.OrdersService.Application.Features.Users.CreateUser;
using Contracts;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.OrdersService.Api.IntegrationEventConsumers;

[ApiController]
[Route("integrations/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) => _mediator = mediator;

    [Topic("pubsub", nameof(UserCreated))]
    [HttpPost]
    public async Task<IActionResult> Create(UserCreated user) =>
        base.Ok(await _mediator.Send(new CreateUserCommand(user)));
}