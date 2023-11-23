using Blog.API.Entities;

namespace Blog.API.Models;

public class PublicPostDto
{
    public PublicPostDto() { }
    public PublicPostDto(Post post)
    {
        Title = post.Title;
    }
    public string? Title { get; set; }
    public int NumberOfComments
        => Comments.Count;
    public ICollection<CommentDto> Comments { get; set; }
}