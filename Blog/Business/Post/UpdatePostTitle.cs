using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record UpdatePostTitle(int PostId, string Title) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostTitle>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(UpdatePostTitle request, CancellationToken cancellationToken)
        {
            var post = await context.Posts
                .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken);

            if (post == null || post.AuthorId != httpContextAccessor.HttpContext.User.Identity.Name)
            {
                throw new UnauthorizedAccessException();
            }
            post.Title = request.Title;
            await context.SaveChangesAsync(cancellationToken);
            return default;
        } 
    }
}