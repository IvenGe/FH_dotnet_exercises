using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("AuthorId")]
    public string AuthorId { get; set; }

    public User Author { get; set; }

    public string? AuthorName { get; set; }

    public DateTime DatePublished { get; set; } = DateTime.UtcNow;

    [Required]

    [MaxLength(200)]
    public string? Title { get; set;}

    public string? Content { get; set; }


    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();

    public Post()
    {
    }

}