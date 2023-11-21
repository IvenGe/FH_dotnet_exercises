namespace FH_dotnet_exercises.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
    public int UserId { get; set; }
    public User Author { get; set; }
  //  public ICollection<Comment> Comments { get; set; }
}
