using System.ComponentModel.DataAnnotations;

namespace Quiz2.Entities
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
