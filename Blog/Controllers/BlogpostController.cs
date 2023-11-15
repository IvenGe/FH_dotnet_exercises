using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BlogPostController : ControllerBase
{
    private readonly BloggingContext _context;

    public BlogPostController(BloggingContext context)
    {
        _context = context;
    }

    // HTTP methods (GET, POST, PUT, DELETE) for blog posts
}

// Similar structure for UserController and CommentController