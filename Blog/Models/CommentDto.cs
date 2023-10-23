using Blog.API.Entities;

namespace Blog.API.Models;

public class CommentDto
{
    public CommentDto() { }

    public CommentDto(Comment comment)
    {
        Id = comment.Id;
        Name = comment.Name;
        Text = comment.Text;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Text { get; set; }
}