using System.Security.Claims;
using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record DeleteComment(int PostId, int CommentId) : ICommand
{
    public class Handler : IRequestHandler<DeleteComment>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.SingleRequiredAsync(x =>
            x.Id == request.CommentId
            && x.PostId == request.PostId,
            cancellationToken);

            var currentUserId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId == null)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            if (comment.AuthorId != currentUserId)
            {
                throw new UnauthorizedAccessException("You are not the author of this comment");
            }

            context.Comments.Remove(comment);
            await context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}