using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly BloggingContext _context;

    public CommentController(BloggingContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
    }

    // Methods for GetComment, UpdateComment, etc.
    [HttpPut("{id}")]
public async Task<IActionResult> UpdateCommantPost(int id, BlogPost blogPost)
{
    // Check if the user is the author of the blog post
    // Update the post if they are
    // Save changes and return some result
}
}