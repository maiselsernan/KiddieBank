using KiddieBank.DTOs;

namespace KiddieBank.Web.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync(int userId);
    }
}
