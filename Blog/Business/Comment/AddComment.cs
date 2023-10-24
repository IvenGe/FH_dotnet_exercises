using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record AddComment(string Name, string? Text, int PostId) :
ICommand<CommentDto>
{
    public class Handler : IRequestHandler<AddComment, CommentDto>
    {
        private readonly PostInfoContext context;
        
        public Handler(PostInfoContext context) => this.context = context; 

        public async Task<CommentDto> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var post = await context.Posts
                .SingleRequiredAsync(x => x.Id == request.PostId, cancellationToken);

            var comment = new Entities.Comment(request.Name)
            {
                Text = request.Text
            };

            post.Comments.Add(comment);
            await context.SaveChangesAsync(cancellationToken);
            return new CommentDto(comment);
        }
    }
}