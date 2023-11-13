using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPosts(string? Name = null) : IQuery<GetPosts.Result>
{
    public record Result(IEnumerable<PostDto> Items);
    public class Handler : IRequestHandler<GetPosts, Result>
        {
        private readonly PostInfoContext context;
        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Result> Handle(GetPosts request, CancellationToken
        cancellationToken)
        {
            var queryable = context.Posts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                queryable = queryable.Where(x => x.Name == request.Name);
            }

            return new Result(await queryable.Select(x => new PostDto(x))
                .ToListAsync(cancellationToken));
        }
    }
}