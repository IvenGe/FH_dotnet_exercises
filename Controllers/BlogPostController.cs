using FH_dotnet_exercises.Services;
using FH_dotnet_exercises.Models; // Replace with your actual namespace for BlogPost
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FH_dotnet_exercises.Controllers;
[ApiController]
[Route("[controller]")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public BlogPostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _blogPostService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] BlogPost post)
    {
        if (post == null)
        {
            return BadRequest("Blog post is null.");
        }

        await _blogPostService.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _blogPostService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    // Other actions like Put, Delete
}
