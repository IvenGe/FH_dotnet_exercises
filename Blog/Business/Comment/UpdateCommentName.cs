using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentName(int PostId, int CommentId, string Name) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentName>
    {
        public Task<Unit> Handle(UpdateCommentName request, CancellationToken cancellationToken)
        {
            var comment = PostsDataStore.Current.Posts
                .Single(x => x.Id == request.PostId)
                .Comments
                .Single(x => x.Id == request.CommentId);

            comment.Name = request.Name;
            return Task.FromResult<Unit>(default);
        } 
    }
}