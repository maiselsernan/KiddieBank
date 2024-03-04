using KiddieBank.Model.Models;
using KiddieBank.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace KiddieBank.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("User/");

        }
    }
}
