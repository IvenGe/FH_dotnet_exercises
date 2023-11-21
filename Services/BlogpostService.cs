using FH_dotnet_exercises.Models; // Replace with the actual namespace of your BlogPost model
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FH_dotnet_exercises.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogDbContext _context;

        public BlogPostService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetPostByIdAsync(int id)
        {
            return await _context.BlogPosts.FirstOrDefaultAsync(post => post.Id == id);
        }

        public async Task CreatePostAsync(BlogPost post)
        { 
           if (post == null)
                throw new ArgumentNullException(nameof(post));

            post.DateCreated = DateTime.UtcNow; // Assuming BlogPost has a DateCreated property
            await _context.BlogPosts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(BlogPost post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            _context.BlogPosts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
       
    }
}
