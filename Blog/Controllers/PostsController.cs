using System.Security.Claims;
using Blog.API.Business.Post;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        this.mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [AllowAnonymous]
    //Controller to get posts
    public async Task<GetPosts.Result> GetPosts(string? searchQuery,
        int pageNumber = 1, int pageSize = 10)
        {
            var result = await mediator.Send(new GetPosts(_httpContextAccessor, null, searchQuery, pageNumber, pageSize));
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PaginationMetadata));
            return result;
        }

    [HttpGet("{id}")]
    [Authorize]
    //Controller to get post by id
    public async Task<PostDto> GetPostById(int id) 
        => await mediator.Send(new GetPostById(id));
    
    [HttpPost]
    [Authorize]
    //Controller for creating a new post
    public async Task<IActionResult> CreatePost(
        [FromBody] CreatePostDto createPostDto)
    {
        var command = new CreatePost(createPostDto);
        var result = await mediator.Send(command);

        return CreatedAtAction(nameof(GetPostById), new { id = result.Id }, result);
    }
}