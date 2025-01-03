

namespace App.Domain.Core.Quiz2.Card.Services
{
    public interface ICardService
    {
        bool PasswordIsValid(string cardNumber, string password);
        void Withdraw(string cardNumber, float amount);
        void Deposit(string cardNumber, float amount);
        void SetWrongPasswordTry(string cardNumber);
        int GetWrongPasswordTry(string cardNumber);
        bool CardIsActive(string cardNumber);
        App.Domain.Core.Quiz2.Card.Entities.Card GetCardBy(string cardNumber);
        void ClearWrongPasswordTry(string cardNumber);
        void ChangePassword(string cardNumber, string password);
        void SaveChanges();
        public float getBalance(string cardNumber);
    }
}
