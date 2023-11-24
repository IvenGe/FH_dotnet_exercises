using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class CommentTitleForUpdateDto
{
    [Required(ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]
    public string? Title { get; set; }

}