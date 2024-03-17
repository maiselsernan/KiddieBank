using KiddieBank.Api.Interfaces;
using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KiddieBank.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        // POST: api/account/register
        [HttpPost("register")]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto registerDto)
        {
            var user = await _accountRepository.Register(registerDto);
            if (user == null) return BadRequest("Username is taken");
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto loginDto)
        {
            var user = await _accountRepository.Login(loginDto);
            if (user == null) return Unauthorized("Invalid username or password");
            return Ok(user);
        }
    }
    
}
