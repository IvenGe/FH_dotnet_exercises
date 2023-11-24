using System.Security.Claims;
using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record UpdatePostContent(int PostId, string? Content) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostContent>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(UpdatePostContent request, CancellationToken cancellationToken)
        {
            var post = await context.Posts
                .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken);
            
            var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (post.AuthorId != currentUserId)
            {
                throw new UnauthorizedAccessException("You are not the author of this post");
            }
            post.Content = request.Content;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}