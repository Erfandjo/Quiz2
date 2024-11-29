namespace Quiz2.Contracts
{
    public interface ICardService
    {
        Result Transfer(string sourceCardNumber, string destinationCardNumber, float TransferAmount);
        Result Login(string cardNumber, string password);
        void CheckTryLogin(string cardNumber);
    }
}
