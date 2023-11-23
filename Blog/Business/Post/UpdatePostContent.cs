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
            if (post == null || post.AuthorId != httpContextAccessor.HttpContext.User.Identity.Name)
            {
                throw new UnauthorizedAccessException();
            }
            post.Content = request.Content;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}