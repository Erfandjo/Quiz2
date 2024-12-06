using Quiz2.Entities;

namespace Quiz2.Contracts
{
    public interface ICardService
    {
        Result PasswordIsValid(string cardNumber, string password);
        public Result DisplayInformationTransfer(string cardNumber , float amount);
        public float GetBalance(string cardNumber);
        public void ChangePassword(string cardNumber, string password);
    }
}
