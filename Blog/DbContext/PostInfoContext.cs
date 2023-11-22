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
            new Comment("Mike")
            {
                Id = 1,
                PostId = 1,
                Text = "Database cooooool"
            },
            new Comment("Tim")
            {
                Id = 2,
                PostId = 1,
                Text = "okok"
            },
            new Comment("Al")
            {
                Id = 3,
                PostId = 2,
                Text = "yee"
            },
            new Comment("user")
            {
                Id = 4,
                PostId = 3,
                Text = "sup"
            });
        
    }
}
