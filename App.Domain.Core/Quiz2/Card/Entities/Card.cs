using App.Domain.Core.Quiz2.User.Entities;

using App.Domain.Core.Quiz2.Transaction.Entities;
namespace App.Domain.Core.Quiz2.Card.Entities
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
        public App.Domain.Core.Quiz2.User.Entities.User User { get; set; }
        public List<App.Domain.Core.Quiz2.Transaction.Entities.Transaction> TransactionsAsSource { get; set; }
        public List<App.Domain.Core.Quiz2.Transaction.Entities.Transaction> TransactionsAsDestination { get; set; }
     
    }
}
