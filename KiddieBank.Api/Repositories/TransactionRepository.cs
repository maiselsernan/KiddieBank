using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace KiddieBank.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly KiddieBankContext _context;

        public TransactionRepository(KiddieBankContext context)
        {
            _context = context;
        }
        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int userId)
        {
            return await _context.Transactions.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
