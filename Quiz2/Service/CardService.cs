using Quiz2.Contracts;
using Quiz2.Entities;
using Quiz2.Repository;
using System.Transactions;

namespace Quiz2.Service
{
    public class CardService : ICardService
    {
      

        private readonly ICardRepository _cardRepository;

       
        public CardService()
        {
            _cardRepository = new CardRepository();
        }
  
        public Result PasswordIsValid(string cardNumber, string password)
        {
            var tryCount = _cardRepository.GetWrongPasswordTry(cardNumber);

            if (tryCount > 3)
                return new Result(false , "You have entered the wrong password 3 times. Your account is permanently blocked");

            var passwordIsValid = _cardRepository.PasswordIsValid(cardNumber, password);

            if (passwordIsValid == false)
            {
                _cardRepository.SetWrongPasswordTry(cardNumber);
                return new Result(false, "Card number Or Password Is Wrong");
            }
            else
            {
                _cardRepository.ClearWrongPasswordTry(cardNumber);
                return new Result(true, "Welcome");
            }
        }

        public float GetBalance(string cardNumber)
        {
            return _cardRepository.getBalance(cardNumber);
        }

        public void ChangePassword(string cardNumber , string password)
        {
            _cardRepository.ChangePassword(cardNumber , password);
        }
        public Result DisplayInformationTransfer(string cardNumber , float amount)
        {
            var card = _cardRepository.GetCardBy(cardNumber);
            if(card is not null)
            {
                return new Result(true, $"Destination Card Number : {card.CardNumber} , Amount : {amount} , Full Name : {card.User.FirstName} {card.User.LastName}");
            }
            else
            {
                return new Result(false, "Not Found Card For Destination Card Number");
               
            }
           
        }

        
    }
    }

