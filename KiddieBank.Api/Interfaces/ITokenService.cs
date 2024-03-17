using KiddieBank.Model.Models;

namespace KiddieBank.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
