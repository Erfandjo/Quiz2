namespace App.Domain.Core.Quiz2.Card.AppServices
{
    public interface ICardAppService
    {
        App.Domain.Core.Quiz2.Result.Result PasswordIsValid(string cardNumber, string password);
        public App.Domain.Core.Quiz2.Result.Result DisplayInformationTransfer(string cardNumber, float amount);
        public float GetBalance(string cardNumber);
        public void ChangePassword(string cardNumber, string password);
        public App.Domain.Core.Quiz2.Card.Entities.Card GetbyCardNumber(string cardNumber);
    }
}

