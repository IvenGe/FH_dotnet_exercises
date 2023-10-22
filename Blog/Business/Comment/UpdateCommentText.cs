using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record UpdateCommentText(int PostId, int CommentId, string? Text) : ICommand
{
    public class Handler : IRequestHandler<UpdateCommentText>
    {
        public Task<Unit> Handle(UpdateCommentText request, CancellationToken cancellationToken)
        {
            var comment = PostsDataStore.Current.Posts
                .Single(x => x.Id == request.PostId)
                .Comments
                .Single(x => x.Id == request.CommentId);

            comment.Text = request.Text;
            return Task.FromResult<Unit>(default);
        } 
    }
}