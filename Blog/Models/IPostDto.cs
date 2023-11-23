using Blog.API.Entities;

namespace Blog.API.Models;

public interface IPostDto
{
    string? Title { get; set; }
    public DateTime DatePublished { get; set; }
    public int NumberOfComments { get; set; }
}