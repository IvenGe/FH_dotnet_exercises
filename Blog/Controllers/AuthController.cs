using Blog.API.Business.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;
    
    public AuthController(IMediator mediator) => this.mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUser request)
    {
        var result = await mediator.Send(request);
        return !result.Succeeded ? new BadRequestObjectResult(result) : Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateUser request)
    {
        var result = await mediator.Send(request);
        if (!result.Successful)
            return Unauthorized();
        return Ok(result);
    }
}