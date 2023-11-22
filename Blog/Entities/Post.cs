using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string? Title { get; set;}

    public string? Content { get; set; }

    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();

    public Post(string name)
    {
        Name = name;
    }

}