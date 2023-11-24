using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record GetCommentsByPostId(int PostId) :
IQuery<GetCommentsByPostId.Result>
{
    public record Result(IEnumerable<CommentDto> Items);
    public class Handler : IRequestHandler<GetCommentsByPostId, Result>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<Result> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
            {
                var post = await context.Posts
                    .Include(p => p.Comments)
                        .ThenInclude(c => c.Author)
                    .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken);
                return new Result(post.Comments
                        .Select(x => new CommentDto(x)));
            }
    }

}
