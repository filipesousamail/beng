using beng.user.service.Application.Features.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace beng.UsersService.Application.Features;

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
        return response is not null ? Ok(response) : NotFound();
    }
}