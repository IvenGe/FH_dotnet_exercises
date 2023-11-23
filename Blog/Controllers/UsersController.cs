using Blog.API.Models;
using Blog.API.Business.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        this.mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("{userName}")]
    [Authorize]
    //Controller to get users
    public async Task<UserDto> GetUserByUserName(string userName)
        => await mediator.Send(new GetUserByUserName(userName));

}