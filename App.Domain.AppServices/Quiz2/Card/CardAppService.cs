using App.Domain.Core.Quiz2.Card.AppServices;
using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.Card.Services;
using App.Domain.Core.Quiz2.Result;
using App.Domain.Services.Quiz2.Card;
using App.Infra.Data.Db.Storage.Memory;
using App.Infra.Data.Repos.Ef.Quiz2.Card;
using System.Transactions;

namespace App.Domain.AppServices.Quiz2.Card
{
    public class CardAppService : ICardAppService
    {


        private readonly ICardService _cardService;


        public CardAppService(ICardService cardService)
        {
            _cardService = cardService;
        }

        public Result PasswordIsValid(string cardNumber, string password)
        {
            var tryCount = _cardService.GetWrongPasswordTry(cardNumber);

            if (tryCount > 3)
                return new Result(false, "You have entered the wrong password 3 times. Your account is permanently blocked");

            var passwordIsValid = _cardService.PasswordIsValid(cardNumber, password);

            if (passwordIsValid == false)
            {
                _cardService.SetWrongPasswordTry(cardNumber);
                return new Result(false, "Card number Or Password Is Wrong");
            }
            else
            {
                _cardService.ClearWrongPasswordTry(cardNumber);
                CurrentUser.OnlineUser = _cardService.GetCardBy(cardNumber);
                return new Result(true, "Welcome");
            }
        }

        public float GetBalance(string cardNumber)
        {
            return _cardService.getBalance(cardNumber);
        }

        public void ChangePassword(string cardNumber, string password)
        {
            _cardService.ChangePassword(cardNumber, password);
        }
        public Result DisplayInformationTransfer(string cardNumber, float amount)
        {
            var card = _cardService.GetCardBy(cardNumber);
            if (card is not null)
            {
                return new Result(true, $"Destination Card Number : {card.CardNumber} , Amount : {amount} , Full Name : {card.User.FirstName} {card.User.LastName}");
            }
            else
            {
                return new Result(false, "Not Found Card For Destination Card Number");

            }

        }

        public Core.Quiz2.Card.Entities.Card GetbyCardNumber(string cardNumber)
        {
            return _cardService.GetCardBy(cardNumber);
        }
    }
}

