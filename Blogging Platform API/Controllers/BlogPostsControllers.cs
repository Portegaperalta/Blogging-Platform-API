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

        //POST: /posts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Post post)
        {

            context.Add(post);
            await context.SaveChangesAsync();
            return Created();
        }

        //PUT: /posts/id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Post post)
        {
            if (id != post.Id)
            {
                ModelState.AddModelError(nameof(post.Id), "The posts id's must match");
                return ValidationProblem();
            }

            context.Update(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        //DELETE: /posts/id 
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deletedRecords = await context.Posts.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedRecords == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
