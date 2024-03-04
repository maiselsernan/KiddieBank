using KiddieBank.Model.Models;

namespace KiddieBank.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
