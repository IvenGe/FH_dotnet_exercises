using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentText(int PostId, int CommentId, string? Content) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentText>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Unit> Handle(UpdateCommentText request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments
                .SingleRequiredAsync(x => x.PostId == request.PostId
                                        && x.Id == request.CommentId, cancellationToken);
            comment.Content = request.Content;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}