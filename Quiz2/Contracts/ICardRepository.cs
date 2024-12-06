using Quiz2.Entities;

namespace Quiz2.Contracts
{
    public interface ICardRepository
    {
        bool PasswordIsValid(string cardNumber, string password);
        void Withdraw(string cardNumber, float amount);
        void Deposit(string cardNumber, float amount);
        void SetWrongPasswordTry(string cardNumber);
        int GetWrongPasswordTry(string cardNumber);
        bool CardIsActive(string cardNumber);
        Card GetCardBy(string cardNumber);
        void ClearWrongPasswordTry(string cardNumber);
        void ChangePassword(string cardNumber, string password);
        void SaveChanges();
        public float getBalance(string cardNumber);
    }
}
