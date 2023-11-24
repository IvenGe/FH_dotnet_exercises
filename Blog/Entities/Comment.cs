using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string AuthorId { get; set; } = string.Empty;

    public User Author { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(200)]
    public string? Content { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;



    [ForeignKey("PostId")]
    public Post? Post { get; set; }
    public int PostId { get; set; }
    public Comment()
    {
    }

}