using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentName(int PostId, int CommentId, string Name) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentName>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Unit> Handle(UpdateCommentName request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments
                .SingleRequiredAsync(x => x.PostId == request.PostId
                                        && x.Id == request.CommentId, cancellationToken);
            comment.Name = request.Name;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}