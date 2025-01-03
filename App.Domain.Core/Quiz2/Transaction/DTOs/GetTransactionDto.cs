namespace App.Domain.Core.Quiz2.Transaction.DTOs
{
    public class GetTransactionsDto
    {
        public string SourceCardNumber { get; set; }
        public string DestinationsCardNumber { get; set; }
        public DateTime ActionAt { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }
    }
}
