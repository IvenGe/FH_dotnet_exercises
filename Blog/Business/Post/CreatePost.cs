using MediatR;
using Blog.API.Models;
using Blog.API.DbContexts;
using Fusonic.Extensions.MediatR;
using System.Security.Claims;

namespace Blog.API.Business.Post;
// Create a new post
public record CreatePost(CreatePostDto CreatePostDto) : 
ICommand<PostDto>
{
    public class Handler : IRequestHandler<CreatePost, PostDto>
    {
        private readonly PostInfoContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(PostInfoContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PostDto> Handle(CreatePost request, CancellationToken cancellationToken)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("AuthorId cannot be null");
            }
            var author = await context.Users.FindAsync(userId) ?? throw new InvalidOperationException("Author not found");
            var post = new Entities.Post()
            {
                Title = request.CreatePostDto.Title,
                Content = request.CreatePostDto.Content,
                AuthorId = userId,
                Author = author
            };

            context.Posts.Add(post);
            await context.SaveChangesAsync(cancellationToken);
            return new PostDto(post);
        }
    }
}