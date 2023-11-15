using Blog.API.Business.Post;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator mediator;

    public PostsController(IMediator mediator) => this.mediator = mediator;
    [HttpGet]
    public async Task<GetPosts.Result> GetPosts(string? name, string? searchQuery,
        int pageNumber = 1, int pageSize = 10)
        {
            var result = await mediator.Send(new GetPosts(name, searchQuery, pageNumber, pageSize));
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PaginationMetadata));
            return result;
        }

    [HttpGet("{id}")]
    public async Task<PostDto> GetPostById(int id) 
        => await mediator.Send(new GetPostById(id));
}