using Blogging_Platform_API.Data.Repositories;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IEnumerable<Post>> GetBlogPostsAsync()
        {
            return await _blogPostRepository.GetBlogPostsAsync();
        }

        public async Task<Post?> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id);
            return blogPost;
        }

        public async Task CreateBlogPostAsync(Post post)
        {
            await _blogPostRepository.CreateBlogPostAsync(post);
        }

        public async Task UpdateBlogPostAsync(int id, Post post)
        {
            if (id != post.Id)
            {
                throw new ArgumentException("The post id's must match");
            }

            await _blogPostRepository.UpdateBlogPostAsync(post);
        }

        public async Task<int> DeleteBlogPostAsync(int id)
        {
            var deletedRecords = await _blogPostRepository.DeleteBlogPostAsync(id);
            return deletedRecords;
        }
    }
}
