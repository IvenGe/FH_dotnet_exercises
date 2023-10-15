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
                Description = "Today was a good day",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Name = "Frank",
                        Description = "Ok"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Description = "Cool"
                    }
                }
            },
            new PostDto()
            {
                Id = 2,
                Name = "Coffee",
                Description = "Coffee is so good",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Name = "Frank",
                        Description = "Was it Dark brew?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Description = "I Like Tea more"
                    }
                }
            },
            new PostDto()
            {
                Id = 3,
                Name = "Beer",
                Description = "Beer is good",
                Comments = new List<CommentDto>()
                {
                    new CommentDto() {
                        Id = 1,
                        Name = "Frank",
                        Description = "How strong was it?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Description = "I dont drink beer"
                    }
                }
            }
        };
    }
}