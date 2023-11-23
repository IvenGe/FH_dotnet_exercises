using Microsoft.AspNetCore.Identity;

namespace Blog.API.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Comment> Comments { get; set; }
            = new List<Comment>();

        public virtual ICollection<Post> Posts { get; set; }
            = new List<Post>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        

        public static implicit operator User(string v)
        {
            throw new NotImplementedException();
        }
    }
}