namespace Blog.API.Models;

public class PostDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int NumberOfComments
        => Comments.Count;
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
}