using Blog.API.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Blog.API.Models;

public class CommentDto
{
    public CommentDto() { }

    public CommentDto(Comment comment)
    {
        Id = comment.Id;
        AuthorName = comment.AuthorName;
        Title = comment.Title;
        Content = comment.Content;
        Timestamp = comment.Timestamp;
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}