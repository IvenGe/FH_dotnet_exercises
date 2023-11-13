using Blog.API.Business.Post;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator mediator;

    public PostsController(IMediator mediator) => this.mediator = mediator;
    [HttpGet]
    public async Task<GetPosts.Result> GetPosts(string? name, string? searchQuery) 
        => await mediator.Send(new GetPosts(name, searchQuery));

    [HttpGet("{id}")]
    public async Task<PostDto> GetPostById(int id) 
        => await mediator.Send(new GetPostById(id));
}