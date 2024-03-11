using KiddieBank.DTOs;

namespace KiddieBank.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}
