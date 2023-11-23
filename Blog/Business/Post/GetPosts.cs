using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPosts(
    IHttpContextAccessor httpContextAccessor,
    string? Title = null,
    string? SearchQuery = null,
    int PageNumber = 1,
    int PageSize = 10) : IQuery<GetPosts.Result>
{
    public record Result(IEnumerable<IPostDto> Posts, PaginationMetadata PaginationMetadata);
    public class Handler : IRequestHandler<GetPosts, Result>
        {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result> Handle(GetPosts request, CancellationToken
        cancellationToken)
        {
            var queryable = context.Posts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                queryable = queryable.Where(x => x.Title == request.Title);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchQuery))
            {
                queryable = queryable.Where(x => x.Title.Contains(request.SearchQuery)
                                                 || x.Title!.Contains(request.SearchQuery));
            }
            var totalItemsCount = await queryable.CountAsync(cancellationToken);

            var paginationMetadata = new PaginationMetadata(
                totalItemsCount,
                request.PageSize,
                request.PageNumber);

            var isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var detailedPosts = await queryable
                    .OrderByDescending(p => p.Comments.Count)
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .Select(p => new PostDto(p))
                    .ToListAsync(cancellationToken);

                return new Result(detailedPosts.Cast<IPostDto>(), paginationMetadata);
            }
            else
            {
                var publicPosts = await queryable
                    .OrderByDescending(p => p.Comments.Count)
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .Select(p => new PublicPostDto
                    {
                        Title = p.Title,
                        DatePublished = p.DatePublished,
                        NumberOfComments = p.Comments.Count
                    })
                    .ToListAsync(cancellationToken);

                return new Result(publicPosts.Cast<IPostDto>(), paginationMetadata);
                
            }

        }
    }
}