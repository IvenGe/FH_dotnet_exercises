namespace FH_dotnet_exercises.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    // Additional properties like Email, PasswordHash
    public ICollection<BlogPost> BlogPosts { get; set; }
    public ICollection<Comment> Comments { get; set; }
}