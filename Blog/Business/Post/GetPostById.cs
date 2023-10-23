using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Blog.API.Business.Post;

public record GetPostById(int Id) : IQuery<PostDto>
{
    public class Handler : IRequestHandler<GetPostById, PostDto>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<PostDto> Handle(GetPostById request, CancellationToken
            cancellationToken)
            => new PostDto(await context.Posts.Include(x => x.Comments)
                .SingleRequiredAsync(x => x.Id == request.Id, cancellationToken));
    }
}