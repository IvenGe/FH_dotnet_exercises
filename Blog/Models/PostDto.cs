using Blog.API.Entities;

namespace Blog.API.Models;

public class PostDto
{
    public PostDto() {}
    public PostDto(Post post)
    {
        Id = post.Id;
        Name = post.Name;
        Title = post.Title;
        Content = post.Content;
        Comments = post.Comments
            .Select(comment => new CommentDto(comment)).ToList();
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int NumberOfComments
        => Comments.Count;
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
}