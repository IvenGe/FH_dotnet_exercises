using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class PostContentForUpdateDto
{
    [Required(ErrorMessage = "You should provide a title value.")]
    [MaxLength(1000)]
    public string? Content { get; set; }
}