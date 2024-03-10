using KiddieBank.Model.Models;
using KiddieBank.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace KiddieBank.Web.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _httpClient;

        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Transaction>>($"Transaction/{userId}");
        }
    }
}
