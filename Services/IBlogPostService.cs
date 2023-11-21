namespace FH_dotnet_exercises.Services;
using FH_dotnet_exercises.Models;
public interface IBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAllPostsAsync();
    Task<BlogPost> GetPostByIdAsync(int id);
    Task CreatePostAsync(BlogPost post);
    Task UpdatePostAsync(BlogPost post);
    Task DeletePostAsync(int id);

    
    
}