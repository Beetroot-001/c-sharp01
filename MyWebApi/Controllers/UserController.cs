using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var createdUser = await userService.Create(user);
            return Created("", createdUser);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserById([FromRoute]int id, [FromBody] JsonPatchDocument<User> user)
        {
            var updatedUser = await userService.Update(id, user);

            return Created("", updatedUser);
        }

        [MyCustomAuth]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.Delete(id);

            return NoContent();
        }


    }
}
