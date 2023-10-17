using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record GetPosts() : IQuery<GetPosts.Result>
{
    public record Result(IEnumerable<PostDto> Items);

    public class Handler : IRequestHandler<GetPosts, Result>
    {
        public Task<Result> Handle(GetPosts request, CancellationToken
            cancellationToken)
            => Task.FromResult(new Result(PostsDataStore.Current.Posts));
    }

}