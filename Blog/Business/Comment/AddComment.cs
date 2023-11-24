using System.Security.Claims;
using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record AddComment(CommentForCreationDto CommentForCreationDto, int PostId) :
ICommand<CommentDto>
{
    public class Handler : IRequestHandler<AddComment, CommentDto>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CommentDto> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("AuthorId cannot be null");
            }

            var author = await context.Users.FindAsync(userId) ?? throw new InvalidOperationException("Author not found");
            var post = await context.Posts
                .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken)
                ?? throw new InvalidOperationException("Post not found");

            var comment = new Entities.Comment()
            {
                Title = request.CommentForCreationDto.Title,
                Content = request.CommentForCreationDto.Content,
                PostId = request.PostId,
                AuthorId = userId,
                Author = author
            };

            post.Comments.Add(comment);
            await context.SaveChangesAsync(cancellationToken);
            return new CommentDto(comment);
        }
    }
}