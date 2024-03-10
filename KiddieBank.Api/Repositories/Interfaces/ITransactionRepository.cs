using KiddieBank.Model.Models;

namespace KiddieBank.Api.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(int userId);
    }
}
