using Blog.API.Models;

namespace Blog.API;

public class PostsDataStore
{
    public List<PostDto> Posts { get; set; }
    public static PostsDataStore Current { get; } = new PostsDataStore();

    public PostsDataStore()
    //dummy data
    {
        Posts = new List<PostDto>()
        {
            new PostDto()
            {
                Id = 1,
                Name = "Today",
                Title = "Today was a good day",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Title = "Frank",
                        Content = "Ok"
                    },
                    new CommentDto() {
                        Id = 2,
                        Title = "Hank",
                        Content = "Cool"
                    }
                }
            },
            new PostDto()
            {
                Id = 2,
                Name = "Coffee",
                Title = "Coffee is so good",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Title = "Frank",
                        Content = "Was it Dark brew?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Title = "Hank",
                        Content = "I Like Tea more"
                    }
                }
            },
            new PostDto()
            {
                Id = 3,
                Name = "Beer",
                Title = "Beer is good",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Title = "Frank",
                        Content = "How strong was it?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Title = "Hank",
                        Content = "I dont drink beer"
                    }
                }
            }
        };
    }
}