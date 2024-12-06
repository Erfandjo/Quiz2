namespace Quiz2.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public DateTime ActionAt { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool isSuccessful { get; set; }
        public Card SourceCard { get; set; }
    }
}
