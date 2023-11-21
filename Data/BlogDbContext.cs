using Microsoft.EntityFrameworkCore;
using FH_dotnet_exercises.Models;

public class BlogDbContext : DbContext
{
     public BlogDbContext() { }

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships and configurations
    }
}