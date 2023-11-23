using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class PostForUpdateDto
{
    [Required(ErrorMessage = "You should provide a title value.")]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string? Content { get; set; }
}