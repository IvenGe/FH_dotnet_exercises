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
                        Text = "Ok"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Text = "Cool"
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
                        Text = "Was it Dark brew?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Text = "I Like Tea more"
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
                        Text = "How strong was it?"
                    },
                    new CommentDto() {
                        Id = 2,
                        Name = "Hank",
                        Text = "I dont drink beer"
                    }
                }
            }
        };
    }
}