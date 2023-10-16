using Blog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet("{commentid}", Name = "GetComment")]
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

    [HttpPost]
    [Produces("application/json")]
    public ActionResult<CommentDto> CreateComment(
        int postId, CommentForCreationDto comment)
    {
        var post = PostsDataStore.Current.Posts
            .FirstOrDefault(p => p.Id == postId);
        if (post == null)
        {
            return NotFound();
        }

        // demo purposes - to be improved
        var maxCommentId = PostsDataStore.Current.Posts
            .SelectMany(p => p.Comments).Max(c => c.Id);

        var finalComment = new CommentDto()
        {
            Id = ++maxCommentId,
            Name = comment.Name,
            Text = comment.Text
        };

        post.Comments.Add(finalComment);

        return CreatedAtRoute("GetComment",
            new {
                postId, commentId = finalComment.Id
                },
            finalComment);
    }

    [HttpPut("{commentId}")]
    public ActionResult UpdateComment(int postId, int commentId, CommentForUpdateDto comment)
    {
        var post = PostsDataStore.Current.Posts
            .FirstOrDefault(p => p.Id == postId);
        if (post == null)
        {
            return NotFound();
        }

        // find comment
        var commentFromStore = post.Comments
            .FirstOrDefault(p => p.Id == commentId);
        if (commentFromStore == null)
        {
            return NotFound();
        }

        commentFromStore.Name = comment.Name;
        commentFromStore.Text = comment.Text;

        return NoContent();
    }
    [HttpPatch("{commentId}")]
    public ActionResult PartiallyUpdateComment(
        int postId, int commentId,
        JsonPatchDocument<CommentForUpdateDto> patchDocument)
        {
            var post = PostsDataStore.Current.Posts
                .FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound();
            }

            // find comment
            var commentFromStore = post.Comments
                .FirstOrDefault(p => p.Id == commentId);
            if (commentFromStore == null)
            {
                return NotFound();
            }

            var commentToPatch = 
                new CommentForUpdateDto()
                {
                    Name = commentFromStore.Name,
                    Text = commentFromStore.Text
                };

            patchDocument.ApplyTo(commentToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(commentToPatch))
            {
                return BadRequest(ModelState);
            }

            commentFromStore.Name = commentToPatch.Name;
            commentFromStore.Text = commentToPatch.Text;

            return NoContent();

        }

        [HttpDelete("{commentId}")]
        public ActionResult DeleteComment(int postId, int commentId)
        {
            var post = PostsDataStore.Current.Posts
                .FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound();
            }

            // find comment
            var commentFromStore = post.Comments
                .FirstOrDefault(p => p.Id == commentId);
            if (commentFromStore == null)
            {
                return NotFound();
            }

            post.Comments.Remove(commentFromStore);

            return NoContent();
        }
}