using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentText(int PostId, int CommentId, string? Text) : ICommand
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
            comment.Text = request.Text;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}