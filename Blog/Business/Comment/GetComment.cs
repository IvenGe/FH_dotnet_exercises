using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record GetComment(int PostId, int CommentId) :
IQuery<CommentDto>
{
    public class Handler : IRequestHandler<GetComment, CommentDto>
    {
        private readonly PostInfoContext context;
        
        public Handler(PostInfoContext context) => this.context = context;
        public async Task<CommentDto> Handle(GetComment request, CancellationToken cancellationToken)
            => new CommentDto(
                await context.Comments
                .SingleRequiredAsync(x => x.Id == request.CommentId
                                    && x.PostId == request.PostId,
                                    cancellationToken));
    }
}