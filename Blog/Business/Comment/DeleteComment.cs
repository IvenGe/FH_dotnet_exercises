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

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Unit> Handle(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.SingleRequiredAsync(x =>
            x.Id == request.CommentId
            && x.PostId == request.PostId,
            cancellationToken);

            context.Comments.Remove(comment);
            await context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}