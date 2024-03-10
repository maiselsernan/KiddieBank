using KiddieBank.Model.Models;

namespace KiddieBank.Web.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(int userId);
    }
}
