using Blogging_Platform_API.Models;
using Blogging_Platform_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogging_Platform_API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET: /users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        //GET: /users/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: /user
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            await _userService.CreateUserAsync(user);
            return Created();
        }

        // PUT: /user/id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute]int id, [FromBody] User user)
        {

            await _userService.UpdateUserAsync(id, user);
            return Ok();
        }

        // DELETE: /user/id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
