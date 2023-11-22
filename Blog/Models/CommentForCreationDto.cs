using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class CommentForCreationDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]
    public string? Title { get; set; } 
    [MaxLength(200)]
    public string? Content { get; set; }
}
