using beng.UsersService.Application.Features.CreateUser;
using beng.UsersService.Application.Features.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.UsersService.Application.Http;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetUserDetails(Guid id)
    {
        var response = await _mediator.Send(new GetUserQuery(id));
        return response is not null ? Ok(response) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return CreatedAtAction(nameof(GetUserDetails),
            await _mediator.Send(new CreateUserCommand(request.Name)));
    }
}