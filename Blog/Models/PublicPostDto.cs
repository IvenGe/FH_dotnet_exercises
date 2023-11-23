using Blog.API.Entities;

namespace Blog.API.Models;

public class PublicPostDto : IPostDto
{
    public string? Title { get; set; }
    public DateTime DatePublished { get; set; }
    public int NumberOfComments { get; set; }
}