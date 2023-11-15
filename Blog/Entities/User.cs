using Microsoft.AspNetCore.Identity;

namespace Blog.API.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}