using MediatR;
using Blog.API.Models;
using Blog.API.DbContexts;
using Fusonic.Extensions.MediatR;
using System.Security.Claims;

namespace Blog.API.Business.Post;

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
            var fullName = $"{firstName} {lastName}";
            var post = new Entities.Post(fullName)
            {
                Title = request.CreatePostDto.Title,
                Content = request.CreatePostDto.Content,
                DateCreated = DateTime.Now
            };

            context.Posts.Add(post);
            await context.SaveChangesAsync(cancellationToken);
            return new PostDto(post);
        }
    }
}