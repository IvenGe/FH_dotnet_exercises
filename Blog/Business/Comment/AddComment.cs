using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Comment;

public record AddComment(string Name, string? Text, int PostId) :
ICommand<CommentDto>
{
    public class Handler : IRequestHandler<AddComment, CommentDto>
    {
        public Task<CommentDto> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var post = PostsDataStore.Current.Posts.Single(x => x.Id == request.PostId);

            var nextId = PostsDataStore.Current.Posts
                .SelectMany(x => x.Comments)
                .Select(x => x.Id).Max() + 1;

            var comment = new CommentDto
            {
                Id = nextId,
                Name = request.Name,
                Text = request.Text
            };
            post.Comments.Add(comment);
            return Task.FromResult(comment);
        }
    }
}