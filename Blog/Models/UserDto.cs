using Blog.API.Entities;

namespace Blog.API.Models
{
    public class UserDto
    {
        public UserDto() { }

        public UserDto(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Posts = user.Posts.Select(post => new PostDto(post)).ToList();
            Comments = user.Comments.Select(comment => new CommentDto(comment)).ToList();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<PostDto> Posts { get; set; }
            = new List<PostDto>();

        public virtual ICollection<CommentDto> Comments { get; set; }
            = new List<CommentDto>();

        public string Email { get; set; } = string.Empty;
    }
}