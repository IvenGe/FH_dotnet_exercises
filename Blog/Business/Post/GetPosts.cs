using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPosts : IQuery<GetPosts.Result>
{
public record Result(IEnumerable<PostDto> Items);
public class Handler : IRequestHandler<GetPosts, Result>
    {
    private readonly PostInfoContext context;
    public Handler(PostInfoContext context) => this.context = context;
    public async Task<Result> Handle(GetPosts request, CancellationToken
    cancellationToken)
    => new Result(await context.Posts.Include(x => x.Comments)
    .Select(x => new PostDto(x)).ToListAsync(cancellationToken));
}
}