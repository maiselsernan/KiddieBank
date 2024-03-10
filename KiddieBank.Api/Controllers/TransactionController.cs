using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiddieBank.Api.Controllers
{
    [Route(("api/[controller]"))]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        // GET: api/transactions/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync(userId);
            return Ok(transactions);
        }
    }
}
