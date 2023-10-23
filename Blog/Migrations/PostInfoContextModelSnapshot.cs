﻿// <auto-generated />
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Migrations
{
    [DbContext(typeof(PostInfoContext))]
    partial class PostInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.23");

            modelBuilder.Entity("Blog.API.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mike",
                            PostId = 1,
                            Text = "Database cooooool"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tim",
                            PostId = 1,
                            Text = "okok"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Al",
                            PostId = 2,
                            Text = "yee"
                        },
                        new
                        {
                            Id = 4,
                            Name = "user",
                            PostId = 3,
                            Text = "sup"
                        });
                });

            modelBuilder.Entity("Blog.API.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "this is first post using db",
                            Name = "Jarkko"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Yyeyyeyeyeeyeee",
                            Name = "erkki"
                        },
                        new
                        {
                            Id = 3,
                            Description = "heihei",
                            Name = "Kari"
                        });
                });

            modelBuilder.Entity("Blog.API.Entities.Comment", b =>
                {
                    b.HasOne("Blog.API.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Blog.API.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
