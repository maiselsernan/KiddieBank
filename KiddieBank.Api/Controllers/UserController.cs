using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.DTOs;
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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Role = user.Role
                });
            }
            return Ok(usersDto);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
          
            return userDto;
        }
    }
}
