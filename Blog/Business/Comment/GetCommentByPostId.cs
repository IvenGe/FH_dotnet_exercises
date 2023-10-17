using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record GetCommentsByPostId(int PostId) :
IQuery<GetCommentsByPostId.Result>
{
    public record Result(IEnumerable<CommentDto> Items);
    public class Handler : IRequestHandler<GetCommentsByPostId, Result>
    {
        public Task<Result> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
            => Task.FromResult(
                new Result(PostsDataStore.Current.Posts
                    .Single(x => x.Id == request.PostId).Comments));
    }

}
