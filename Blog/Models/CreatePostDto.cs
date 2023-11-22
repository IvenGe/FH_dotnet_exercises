
namespace Blog.API.Models;

//Model for creating a new post

public class CreatePostDto
{

    public string? Title { get; set; }
    public string? Content { get; set; }
}
