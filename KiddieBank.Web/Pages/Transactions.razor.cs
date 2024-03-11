using KiddieBank.DTOs;
using Microsoft.AspNetCore.Components;

namespace KiddieBank.Web.Pages
{
    public partial class Transactions
    {
        [Parameter]
        public string UserId { get; set; }

        private List<TransactionDto> _transactions { get; set; }
        private int _totalAmount;
        protected override async Task OnInitializedAsync()
        {
            _transactions = (await _transactionService.GetTransactionsAsync(int.Parse(UserId))).ToList();
            _totalAmount += _transactions.Sum(transaction => transaction.Type == 1 ? transaction.Amount 
                                                                                   : -transaction.Amount);
        }




    }
}
