using beng.user.service.Application.Features.Users.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.user.service.Application.Features.Users;

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
        var response = await _mediator.Send(new GetUserDetailsQuery(id));
        return response.HasData ? Ok(response) : NotFound();
    }
}