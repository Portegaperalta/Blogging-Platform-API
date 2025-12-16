using Blogging_Platform_API.Data;
using Blogging_Platform_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Controllers
{
    [ApiController]
    [Route("/posts")]
    public class BlogPostsControllers : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public BlogPostsControllers(ApplicationDbContext context)
        {
            this.context = context;
        }

        //GET: /posts
        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await context.Posts.ToListAsync();
        }

        //GET: /posts/id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> Get([FromRoute]int id)
        {
            var post = await context.Posts.
                       FirstOrDefaultAsync(x => x.Id == id);

            if (post is null)
            {
                return NotFound();
            }

            return post;
        }
    }
}
