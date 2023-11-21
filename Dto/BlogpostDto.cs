public class BlogPostDto
{
public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; } // Or AuthorId
    public int Id {get; set;}

    // Add more properties as needed
}