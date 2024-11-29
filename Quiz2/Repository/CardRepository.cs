using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts;
using Quiz2.Entities;
using Quiz2.Infrastructure;

namespace Quiz2.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _appDbContext;

        public CardRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public Card? GetCard(string cardNumber)
        {
            return _appDbContext.Cards.AsNoTracking().FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public void InActiveCard(string cartNumber)
        {
            var cart = _appDbContext.Cards.FirstOrDefault(x => x.CardNumber == cartNumber);
            if ( cart is not null)
            {
                cart.IsActive = false;
                _appDbContext.SaveChanges();
            }
        }

        public bool Login(string cardNumber, string password)
        {
            return _appDbContext.Cards.AsNoTracking().Any(x => x.CardNumber == cardNumber && x.Password == password);
        }

        public void Transfer(string sourceCardNumber, string destinationCardNumber, float transferAmount)
        {
            var sourceCard = _appDbContext.Cards.FirstOrDefault(x => x.CardNumber == sourceCardNumber);
            var destinationCard = _appDbContext.Cards.FirstOrDefault(x => x.CardNumber == destinationCardNumber);
                sourceCard.Balance -= transferAmount;
                destinationCard.Balance += transferAmount;
            _appDbContext.SaveChanges();
        }
    }
}
