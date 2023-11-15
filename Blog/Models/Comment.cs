public class Comment
{
    public int CommentId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CommentedAt { get; set; }
    public User Author { get; set; }
    public BlogPost BlogPost { get; set; }
    // Other properties
}