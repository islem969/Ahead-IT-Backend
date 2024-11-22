using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Models;
using Register.Service;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UtilisateurController : ControllerBase
    {

        private readonly IUserService _userService;

        public UtilisateurController(IUserService userService)
        {
            _userService = userService;
        }

       


        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var userProfile = await _userService.GetUserProfileByIdAsync(id);

            if (userProfile == null)
            {
                return NotFound(); // Retourner 404 si l'utilisateur n'est pas trouvé
            }

            return Ok(userProfile); // Retourner les données de l'utilisateur en réponse HTTP 200 OK
        }
        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var newUser = await _userService.CreateUser(user);
            return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(id, user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

}
}
