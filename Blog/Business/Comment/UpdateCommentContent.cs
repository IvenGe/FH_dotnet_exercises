using System.Security.Claims;
using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentContent(int PostId, int CommentId, string? Content) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentContent>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(UpdateCommentContent request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments
                .SingleRequiredAsync(x => x.PostId == request.PostId
                                        && x.Id == request.CommentId, cancellationToken);
            
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (comment.AuthorId != currentUserId)
            {
                throw new UnauthorizedAccessException("You are not the author of this comment");
            }
            
            comment.Content = request.Content;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}