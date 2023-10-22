using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [ForeignKey("PostId")]
    public Post? Post { get; set; }
    public int PostId { get; set; }
    public Comment(string name)
    {
        Name = name;
    }

}