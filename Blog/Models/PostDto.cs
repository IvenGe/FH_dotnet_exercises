using Blog.API.Entities;

namespace Blog.API.Models;

public class PostDto : IPostDto
{

    public PostDto() { }
    public PostDto(Post post)
    {
        Id = post.Id;
        AuthorName = post.Author.FirstName + " " + post.Author.LastName;  // Assuming Author is a User object with FirstName and LastName
        AuthorUserName = post.Author.UserName;
        DatePublished = post.DatePublished; // Assuming there is a DatePublished property in Post
        Title = post.Title;
        Content = post.Content;
        NumberOfComments = post.Comments.Count;
        Comments = post.Comments.Select(c => new CommentDto(c)).ToList(); // Assuming there is a corresponding constructor in CommentDto
    }
    
    public int Id { get; set; }
    public string AuthorUserName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    
    public DateTime DatePublished { get; set; }

    public string? Title { get; set; }
    public string? Content { get; set; }
    public int NumberOfComments { get; set; }
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
}