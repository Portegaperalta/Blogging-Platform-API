using Blogging_Platform_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetBlogPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetBlogPostByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateBlogPostAsync(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogPostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBlogPostAsync(int id)
        {
            return await _context.Posts.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
