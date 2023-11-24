using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class CommentContentForUpdateDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    [MaxLength(200)]
    public string? Content { get; set; }
}