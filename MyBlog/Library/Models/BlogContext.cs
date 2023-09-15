using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Library.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Blogcommentcount> Blogcommentcounts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Publicblogpost> Publicblogposts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.0.193;Port=5432;Database=blog;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Blogid).HasName("blogs_pkey");

            entity.ToTable("blogs");

            entity.HasIndex(e => e.Createdat, "idx_blogs_createdat");

            entity.Property(e => e.Blogid).HasColumnName("blogid");
            entity.Property(e => e.Authorid).HasColumnName("authorid");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdat");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.Authorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("blogs_authorid_fkey");
        });

        modelBuilder.Entity<Blogcommentcount>(entity =>
        {
            entity.HasKey(e => e.Blogid).HasName("blogcommentcounts_pkey");

            entity.ToTable("blogcommentcounts");

            entity.Property(e => e.Blogid)
                .ValueGeneratedNever()
                .HasColumnName("blogid");
            entity.Property(e => e.Commentcount).HasColumnName("commentcount");

            entity.HasOne(d => d.Blog).WithOne(p => p.Blogcommentcount)
                .HasForeignKey<Blogcommentcount>(d => d.Blogid)
                .HasConstraintName("blogcommentcounts_blogid_fkey");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Commentid).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.HasIndex(e => e.Createdat, "idx_comments_createdat");

            entity.Property(e => e.Commentid).HasColumnName("commentid");
            entity.Property(e => e.Authorid).HasColumnName("authorid");
            entity.Property(e => e.Blogid).HasColumnName("blogid");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdat");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Authorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comments_authorid_fkey");

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Blogid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comments_blogid_fkey");
        });

        modelBuilder.Entity<Publicblogpost>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("publicblogposts");

            entity.Property(e => e.Blogid).HasColumnName("blogid");
            entity.Property(e => e.Commentcount).HasColumnName("commentcount");
            entity.Property(e => e.Publicationdate).HasColumnName("publicationdate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Passwordhash)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
