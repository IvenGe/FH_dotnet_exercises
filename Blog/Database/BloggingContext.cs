using Microsoft.EntityFrameworkCore;


public class BloggingContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public  DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }
}

