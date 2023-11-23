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
            .HasOne(p => p.Author)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

            

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

         
    }
}
