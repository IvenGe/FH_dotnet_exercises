using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPosts(
    string? Name = null,
    string? SearchQuery = null,
    int PageNumber = 1,
    int PageSize = 10) : IQuery<GetPosts.Result>
{
    public record Result(IEnumerable<PostDto> Items, PaginationMetadata PaginationMetadata);
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

            if (!string.IsNullOrWhiteSpace(request.SearchQuery))
            {
                queryable = queryable.Where(x => x.Name.Contains(request.SearchQuery)
                                                 || x.Description!.Contains(request.SearchQuery));
            }
            var totalItemsCount = await queryable.CountAsync(cancellationToken);

            var paginationMetadata = new PaginationMetadata(
                totalItemsCount,
                request.PageSize,
                request.PageNumber);

            return new Result(
                await queryable
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .Select(x => new PostDto(x))
                    .ToListAsync(cancellationToken),
                    paginationMetadata);
        }
    }
}