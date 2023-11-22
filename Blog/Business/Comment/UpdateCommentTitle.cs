using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentTitle(int PostId, int CommentId, string Title) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentTitle>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Unit> Handle(UpdateCommentTitle request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments
                .SingleRequiredAsync(x => x.PostId == request.PostId
                                        && x.Id == request.CommentId, cancellationToken);
            comment.Title = request.Title;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}