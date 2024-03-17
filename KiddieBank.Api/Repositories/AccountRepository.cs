using KiddieBank.Api.Interfaces;
using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.DTOs;
using KiddieBank.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace KiddieBank.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KiddieBankContext _context;
        private readonly ITokenService _tokenService;

        public AccountRepository(KiddieBankContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

     

        public async Task<AppUserDto> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return null;

            using var hmac = new HMACSHA512();
            var user = new User
            {
                Name = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AppUserDto
            {
                UserName = user.Name,
                Token = _tokenService.CreateToken(user)
            };
        }
        public async Task<AppUserDto> Login(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == loginDto.UserName.ToLower());

            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            return new AppUserDto
            {
                UserName = user.Name,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Name == username.ToLower());
        }
    }
}
