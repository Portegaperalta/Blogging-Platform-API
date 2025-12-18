using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<Post>> GetBlogPostsAsync();
        Task<Post?> GetBlogPostByIdAsync(int id);
        Task CreateBlogPostAsync(Post post);
        Task UpdateBlogPostAsync(int id,Post post);
        Task<int> DeleteBlogPostAsync(int id);
    }
}
