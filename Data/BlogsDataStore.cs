public class BlogsDataStore
{
    public static BlogsDataStore Current { get; } = new BlogsDataStore();
    public List<BlogPostDto> Blogs { get; set; }

    public BlogsDataStore()
    {
        // Initialize your Blogs here
        Blogs = new List<BlogPostDto>()
        {
            // Add some initial blog posts
            new BlogPostDto() { Id = 1, Title = "First Blog Post" },
            // ... other blog posts
        };
    }
}