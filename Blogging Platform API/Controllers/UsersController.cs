using Blogging_Platform_API.Data;
using Blogging_Platform_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //GET: /users
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        //GET: /users/id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get([FromRoute]int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: /user
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            int usernameRecords = await context.Users.Where(x => x.Name == user.Name).CountAsync();
            int emailRecords = await context.Users.Where(x => x.Email == user.Email).CountAsync();

            if (usernameRecords > 0)
            {
                return BadRequest("The username already in use");
            }

            if (emailRecords > 0)
            {
                return BadRequest("The email is already in use");
            }

            context.Add(user);
            await context.SaveChangesAsync();
            return Ok();
        }

        // PUT: /user/id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute]int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("The user ids must match");
            }

            context.Update(user);
            await context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: /user/id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var recordsDeleted = await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (recordsDeleted == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
