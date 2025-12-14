using Blogging_Platform_API.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
