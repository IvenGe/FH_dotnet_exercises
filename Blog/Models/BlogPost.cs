public class BlogPost
{
    public int BlogPostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public User Author { get; set; }
    // Other properties
}