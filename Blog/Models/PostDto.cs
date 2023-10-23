using Blog.API.Entities;

namespace Blog.API.Models;

public class PostDto
{
    public PostDto() { }
    public PostDto(Post post)
    {
        Id = post.Id;
        Name = post.Name;
        Description = post.Description;
        Comments = post.Comments.Select(c => new CommentDto(c)).ToList();
    }


    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int NumberOfComments
        => Comments.Count;
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
}