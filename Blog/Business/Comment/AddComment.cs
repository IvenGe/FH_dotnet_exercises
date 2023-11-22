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
            var userClaims = _httpContextAccessor.HttpContext.User.Claims;
            var firstName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
            var lastName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;
            var fullName = $"{firstName} {lastName}";
            var post = await context.Posts
                .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken);

            var comment = new Entities.Comment()
            {
                FullName = fullName,
                Title = request.CommentForCreationDto.Title,
                Content = request.CommentForCreationDto.Content,
                PostId = request.PostId
            };

            post.Comments.Add(comment);
            await context.SaveChangesAsync(cancellationToken);
            return new CommentDto(comment);
        }
    }
}