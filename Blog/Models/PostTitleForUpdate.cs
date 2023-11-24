using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class PostTitleForUpdateDto
{
    [Required(ErrorMessage = "You should provide a title value.")]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

}