namespace FH_dotnet_exercises.Models;
public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DateCreated { get; set; }
    public int BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }
    public int UserId { get; set; }
    public User Author { get; set; }
}