using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record GetComment(int PostId, int CommentId) :
IQuery<CommentDto>
{
    public class Handler : IRequestHandler<GetComment, CommentDto>
    {
        public Task<CommentDto> Handle(GetComment request, CancellationToken cancellationToke)
            => Task.FromResult(
                PostsDataStore.Current.Posts
                    .Single(x => x.Id == request.PostId).Comments.Single(x => x.Id == request.CommentId));
    }
}