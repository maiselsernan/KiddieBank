using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiddieBank.Api.Controllers
{
    [Route(("api/[controller]"))]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly  IUserRepository  _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
