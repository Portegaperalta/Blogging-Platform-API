using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Data.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<Post>> GetBlogPostsAsync();
        Task<Post?> GetBlogPostByIdAsync(int id);
        Task CreateBlogPostAsync(Post post);
        Task UpdateBlogPostAsync(Post post);
        Task<int> DeleteBlogPostAsync(int id);
    }
}
