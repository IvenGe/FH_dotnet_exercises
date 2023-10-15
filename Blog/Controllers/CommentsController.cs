using Blog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/posts/{postId}/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CommentDto>>
        GetComment(int postId)
    {
        var post = PostsDataStore.Current.Posts
            .FirstOrDefault(p => p.Id == postId);

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post.Comments);
    }

    [HttpGet("{commentid}")]
    public ActionResult<CommentDto> GetComment(
        int postId, int commentId)
    {
        var post = PostsDataStore.Current.Posts
            .FirstOrDefault(p => p.Id == postId);
        if (post == null)
        {
            return NotFound();
        }

        // find comment
        var comment = post.Comments
            .FirstOrDefault(p => p.Id == commentId);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment);
    }
}