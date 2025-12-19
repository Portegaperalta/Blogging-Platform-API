using Blogging_Platform_API.Models;
using Blogging_Platform_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogging_Platform_API.Controllers
{
    [ApiController]
    [Route("/posts")]
    public class BlogPostsControllers : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsControllers(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        //GET: /posts
        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _blogPostService.GetBlogPostsAsync();
        }

        //GET: /posts/id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> Get([FromRoute]int id)
        {
            var post = await _blogPostService.GetBlogPostByIdAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            return post;
        }

        //POST: /posts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Post post)
        {

            await _blogPostService.CreateBlogPostAsync(post);
            return Created();
        }

        //PUT: /posts/id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Post post)
        {
            await _blogPostService.UpdateBlogPostAsync(id, post);
            return Ok();
        }

        //DELETE: /posts/id 
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deletedRecords = await _blogPostService.DeleteBlogPostAsync(id);

            if (deletedRecords == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
