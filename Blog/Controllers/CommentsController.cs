using System.ComponentModel.DataAnnotations;
using Blog.API.Business.Comment;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/posts/{postId}/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IMediator mediator;

    public CommentsController(IMediator mediator)
        => this.mediator = mediator;

    [HttpGet]
    public Task<GetCommentsByPostId.Result> GetComments(int postId)
        => mediator.Send(new GetCommentsByPostId(postId));

    [HttpGet("{commentId}", Name = "GetComment")]
    public Task<CommentDto> GetComment(
        int postId, int commentId)
        => mediator.Send(new GetComment(postId, commentId));
    
    public class CommentCreationModel
    {
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Text { get; set; }
    }

[HttpPost]
public async Task<ActionResult<CommentDto>> CreateCommentAsync(
    [FromRoute] int postId,
    [FromBody] CommentCreationModel body)
{
    var comment = await mediator.Send(
        new AddComment(body.Name, body.Text, postId));
    return CreatedAtRoute("GetComment",
        new
        {
            postId,
            commentId = comment.Id 
        }, comment);
}

public record UpdateCommentNameModel([MaxLength(50)] string Name);
[HttpPost("{commentId}/UpdateName")]
public Task<Unit> UpdateCommentName(
    int postId, int commentId,
    [FromBody] UpdateCommentNameModel body)
    => mediator.Send(new UpdateCommentName(postId, commentId, body.Name));

public record UpdateCommentTextModel([MaxLength(200)] string? Text);
[HttpPost("{commentId}/UpdateText")]
public Task<Unit> UpdateCommentText(
    int postId, int commentId,
    [FromBody] UpdateCommentTextModel body)
    => mediator.Send(new UpdateCommentText(postId, commentId, body.Text));

[HttpDelete("{commentId}")]
public Task<Unit> DeleteComment(int postId, int commentId)
=> mediator.Send(new DeleteComment(postId, commentId));

}
