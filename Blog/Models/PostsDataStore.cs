using Blog.API.Models;
using System;
using System.Collections.Generic;

namespace Blog.API;

public class PostsDataStore
{
    public List<PostDto> Posts { get; set; }
    public static PostsDataStore Current { get; } = new PostsDataStore();

    public PostsDataStore()
    {
        Posts = new List<PostDto>()
        {
            new PostDto()
            {
                Id = 1,
                Name = "Today",
                Title = "Today was a good day",
                DateCreated = DateTime.Now,
                Comments = new List<CommentDto>()
                {
                    new CommentDto() { Id = 1, Name = "Frank", Text = "Ok" },
                    new CommentDto() { Id = 2, Name = "Hank", Text = "Cool" }
                }
            },
            new PostDto()
            {
                Id = 2,
                Name = "Coffee",
                Title = "Coffee is so good",
                DateCreated = DateTime.Now,
                Comments = new List<CommentDto>()
                {
                    new CommentDto() { Id = 1, Name = "Frank", Text = "Was it Dark brew?" },
                    new CommentDto() { Id = 2, Name = "Hank", Text = "I Like Tea more" }
                }
            },
            new PostDto()
            {
                Id = 3,
                Name = "Beer",
                Title = "Beer is good",
                DateCreated = DateTime.Now,
                Comments = new List<CommentDto>()
                {
                    new CommentDto() { Id = 1, Name = "Frank", Text = "How strong was it?" },
                    new CommentDto() { Id = 2, Name = "Hank", Text = "I dont drink beer" }
                }
            }
        };
    }
}
