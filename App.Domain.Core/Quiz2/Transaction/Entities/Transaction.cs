using App.Domain.Core.Quiz2.Card.Entities;

namespace App.Domain.Core.Quiz2.Transaction.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public DateTime ActionAt { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }
        public App.Domain.Core.Quiz2.Card.Entities.Card SourceCard { get; set; }
        public App.Domain.Core.Quiz2.Card.Entities.Card DestinationCard { get; set; }
        
    }
}
