using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class CommentForUpdateDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(200)]
    public string? Text { get; set; }
}