using beng.UsersService.Api.Models;
using beng.UsersService.Application.Features.CreateUser;
using beng.UsersService.Application.Features.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.UsersService.Api;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserDetails(Guid id)
    {
        var response = await _mediator.Send(new GetUserQuery(id));
        return response is not null ? Ok(response) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList([FromQuery]GetUsersRequestModel request) =>
        Ok(await _mediator.Send(request.AsGetUserListQuery()));

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return CreatedAtAction(nameof(GetUserDetails),
            await _mediator.Send(new CreateUserCommand(request.Name)));
    }
}