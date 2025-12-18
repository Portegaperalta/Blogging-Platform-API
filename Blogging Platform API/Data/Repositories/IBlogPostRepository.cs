using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Data.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<Post>> GetBlogPostsAsync();
        Task<Post?> GetBlogPostByIdAsync(int id);
        Task CreateBlogPostAsync();
        Task UpdateBlogPostAsync(Post post);
        Task DeleteBlogPostAsync(int id);
    }
}
