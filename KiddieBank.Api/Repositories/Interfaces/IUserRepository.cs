using KiddieBank.Model.Models;

namespace KiddieBank.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
