using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.Card.Services;
using App.Domain.Core.Quiz2.Result;
using App.Infra.Data.Repos.Ef.Quiz2.Card;
using System.Transactions;

namespace App.Domain.Services.Quiz2.Card
{
    public class CardService : ICardService
    {


        private readonly ICardRepository _cardRepository;


        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public bool CardIsActive(string cardNumber)
        {
            return _cardRepository.CardIsActive(cardNumber);
        }

        public void ChangePassword(string cardNumber, string password)
        {
           _cardRepository.ChangePassword(cardNumber, password);
        }

        public void ClearWrongPasswordTry(string cardNumber)
        {
            _cardRepository.ClearWrongPasswordTry(cardNumber);
        }

        public void Deposit(string cardNumber, float amount)
        {
            _cardRepository.Deposit(cardNumber, amount);
        }

        public float getBalance(string cardNumber)
        {
           return _cardRepository.getBalance(cardNumber);
        }

        public Core.Quiz2.Card.Entities.Card GetCardBy(string cardNumber)
        {
           return _cardRepository.GetCardBy(cardNumber);
        }

        public int GetWrongPasswordTry(string cardNumber)
        {
           return _cardRepository.GetWrongPasswordTry(cardNumber);
        }

        public bool PasswordIsValid(string cardNumber, string password)
        {
           return _cardRepository.PasswordIsValid(cardNumber, password);
        }

        public void SaveChanges()
        {
            _cardRepository.SaveChanges();
        }

        public void SetWrongPasswordTry(string cardNumber)
        {
            _cardRepository.SetWrongPasswordTry(cardNumber);
        }

        public void Withdraw(string cardNumber, float amount)
        {
            _cardRepository.Withdraw(cardNumber, amount);
        }
    }
}

