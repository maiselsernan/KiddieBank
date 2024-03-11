using KiddieBank.DTOs;
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
        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TransactionDto>>($"Transaction/{userId}");
        }
    }
}
