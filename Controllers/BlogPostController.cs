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
    public async Task<ActionResult<BlogPostDto>> CreateBlogPost([FromBody] BlogPostForCreationDto blogPostDto)
    {
        // Convert BlogPostForCreationDto to BlogPost entity
        var blogPost = new BlogPost
        {
            Title = blogPostDto.Title,
            Content = "test",
            UserId = 32
            // Set other properties if necessary
        };

         await _blogPostService.CreatePostAsync(blogPost);
         return Ok();
        
        // Ensure "GetBlogPost" matches the actual route name for retrieving a blog post
    }

    [HttpGet("{id}", Name = "GetBlogPost")]
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
