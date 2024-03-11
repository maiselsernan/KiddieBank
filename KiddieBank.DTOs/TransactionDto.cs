namespace KiddieBank.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Type { get; set; }

        public int Amount { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }
    }
}
