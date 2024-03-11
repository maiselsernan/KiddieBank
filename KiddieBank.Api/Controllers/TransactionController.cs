using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.DTOs;
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
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions(int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync(userId);
            var transactionsDto = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                transactionsDto.Add(new TransactionDto
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    Date = transaction.Date,
                    UserId = transaction.UserId,
                    Type = transaction.Type,
                });
            }
            return Ok(transactionsDto);
        }
    }
}
