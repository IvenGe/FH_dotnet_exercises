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

            var userClaims = _httpContextAccessor.HttpContext.User.Claims;
            var firstName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
            var lastName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value; 
            var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var authorName = $"{firstName} {lastName}";
            var post = new Entities.Post()
            {
                AuthorName = authorName.ToString(),
                Title = request.CreatePostDto.Title,
                Content = request.CreatePostDto.Content,
                AuthorId = userId
            };

            if (string.IsNullOrEmpty(userId))
            {

                throw new InvalidOperationException("AuthorId cannot be null");
            }

            context.Posts.Add(post);
            
            await context.SaveChangesAsync(cancellationToken);
            return new PostDto(post);
        }
    }
}