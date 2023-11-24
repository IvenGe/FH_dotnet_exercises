using System.ComponentModel.DataAnnotations;
using Blog.API.Business.Comment;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    

[HttpPost]
[Authorize]
public async Task<ActionResult<CommentDto>> CreateComment(
    [FromRoute] int postId,
    [FromBody] CommentForCreationDto commentForCreationDto)
{
    var commentDto = await mediator.Send(
        new AddComment(commentForCreationDto, postId));
    return CreatedAtRoute("GetComment",
        new
        {
            postId,
            commentId = commentDto.Id 
        }, commentDto);
}

public record UpdateCommentTitleModel([MaxLength(50)] string Title);
[HttpPost("{commentId}/UpdateTitle")]
[Authorize]
public Task<Unit> UpdateCommentTitle(
    int postId, int commentId,
    [FromBody] CommentTitleForUpdateDto body)
    => mediator.Send(new UpdateCommentTitle(postId, commentId, body.Title));

public record UpdateCommentContentModel([MaxLength(200)] string? Content);
[HttpPost("{commentId}/UpdateContent")]
public Task<Unit> UpdateCommentContent(
    int postId, int commentId,
    [FromBody] CommentContentForUpdateDto body)
    => mediator.Send(new UpdateCommentContent(postId, commentId, body.Content));

[HttpDelete("{commentId}")]
public Task<Unit> DeleteComment(int postId, int commentId)
=> mediator.Send(new DeleteComment(postId, commentId));

}
