using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.Card.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Appdb;
using Microsoft.EntityFrameworkCore;


namespace App.Infra.Data.Repos.Ef.Quiz2.Card
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dbContext;

        public CardRepository()
        {
            _dbContext = new AppDbContext();
        }

        public void ChangePassword(string cardNumber, string password)
        {
            var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            if (card is not null)
            {
                card.Password = password;
                _dbContext.SaveChanges();
            }

        }

        public bool PasswordIsValid(string cardNumber, string password)
        => _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.Password == password);

        public bool CardIsActive(string cardNumber)
            => _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.IsActive);

        public App.Domain.Core.Quiz2.Card.Entities.Card GetCardBy(string cardNumber)
        {
            var card = _dbContext.Cards.AsNoTracking().Include(x => x.User).FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"Card with number {cardNumber} not found");
            }
            else
            {
                return card;
            }

        }

        public void ClearWrongPasswordTry(string cardNumber)
        {
            var card = _dbContext.Cards
                .FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }

            card.WrongPasswordTries = 0;
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Withdraw(string cardNumber, float amount)
        {
            var card = _dbContext.Cards
                .FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }

            card.Balance -= amount;
        }

        public void Deposit(string cardNumber, float amount)
        {
            var card = _dbContext.Cards
                .FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }

            card.Balance += amount;
        }

        public void SetWrongPasswordTry(string cardNumber)
        {
            var card = _dbContext.Cards
                .FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }

            card.WrongPasswordTries++;
            _dbContext.SaveChanges();
        }

        public int GetWrongPasswordTry(string cardNumber)
        {
            var card = _dbContext.Cards
                .FirstOrDefault(x => x.CardNumber == cardNumber);

            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }

            return card.WrongPasswordTries;
        }

        public float getBalance(string cardNumber)
        {
            var card = _dbContext.Cards.AsNoTracking().FirstOrDefault(x => x.CardNumber == cardNumber);


            if (card is null)
            {
                throw new Exception($"cannot found card with number {cardNumber}");
            }
            return card.Balance;
        }

    }
}
