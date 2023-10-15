namespace Blog.API.Models;

public class CommentForCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string? Text { get; set; }
}
