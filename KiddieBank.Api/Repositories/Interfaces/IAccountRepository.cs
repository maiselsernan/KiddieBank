using KiddieBank.DTOs;

namespace KiddieBank.Api.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUserDto> Login(LoginDto loginDto);
        Task<AppUserDto> Register(RegisterDto registerDto);
    }
}
