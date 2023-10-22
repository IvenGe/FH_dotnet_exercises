using Blog.API.Entities;
using Blog.API.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Blog.API.DbContexts;

public class PostInfoContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public PostInfoContext(DbContextOptions<PostInfoContext> options)
        : base(options) { }
}
