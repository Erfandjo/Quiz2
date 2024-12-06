using System.ComponentModel.DataAnnotations;

namespace Quiz2.Entities
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public float Balance { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public int WrongPasswordTries { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Transaction> TransactionsAsSource { get; set; }
        public List<Transaction> TransactionsAsDestination { get; set; }
    }
}
