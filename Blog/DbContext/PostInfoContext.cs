using Blog.API.Entities;
using Blog.API.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Blog.API.DbContexts;

public class PostInfoContext : IdentityDbContext<User>
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public PostInfoContext(DbContextOptions<PostInfoContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>().Navigation(x => x.Comments).AutoInclude();
        modelBuilder.Entity<Post>()
            .HasData(
            new Post("Jarkko")
            {
                Id = 1,
                Title = "this is first post using db"
            },
            new Post("erkki")
            {
                Id = 2,
                Title = "Yyeyyeyeyeeyeee"
            },
            new Post("Kari")
            {
                Id = 3,
                Title = "heihei"
            });

        modelBuilder.Entity<Comment>()
         .HasData(
            new Comment()
            {
                Id = 1,
                FullName = "Jarkko",
                PostId = 1,
                Title = "Database",
                Content = "Database cooooool",
                Timestamp = DateTime.UtcNow
            },
            new Comment()
            {
                Id = 2,
                FullName = "erkki",
                PostId = 1,
                Title = "ok",   
                Content = "okok",
                Timestamp = DateTime.UtcNow
            },
            new Comment()
            {
                Id = 3,
                FullName = "Kari",
                PostId = 2,
                Title = "yearfeaee",
                Content = "yee",
                Timestamp = DateTime.UtcNow
            },
            new Comment()
            {
                Id = 4,
                FullName = "Jarkko",
                PostId = 3,
                Title = "hihsadads",
                Content = "sup",
                Timestamp = DateTime.UtcNow
            });
        
    }
}
