using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record DeleteComment(int PostId, int CommentId) : ICommand
{
    public class Handler : IRequestHandler<DeleteComment>
    {
        public Task<Unit> Handle(DeleteComment request, CancellationToken cancellationToken)
        {
            var post = PostsDataStore.Current.Posts
                .Single(x => x.Id == request.PostId);
            var comment = post.Comments
                .Single(x => x.Id == request.CommentId);

            post.Comments.Remove(comment);
            return Task.FromResult<Unit>(default);
        }
    }
}