using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.Card.Services;
using App.Domain.Core.Quiz2.CodeVerify.Data.Repositories;
using App.Domain.Core.Quiz2.CodeVerify.Services;
using App.Domain.Core.Quiz2.Transaction.AppServices;
using App.Domain.Core.Quiz2.Transaction.Data.Repositories;
using App.Domain.Core.Quiz2.Transaction.DTOs;
using App.Domain.Core.Quiz2.Transaction.Services;
using App.Domain.Services.Quiz2.Card;
using App.Domain.Services.Quiz2.CodeVerify;
using App.Domain.Services.Quiz2.Transaction;
using App.Infra.Data.Repos.Ef.Quiz2.Card;
using App.Infra.Data.Repos.Ef.Quiz2.Transaction;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify.Repositories;


namespace App.Domain.AppServices.Quiz2.Transaction
{
    public class TransactionAppService : ITransactionAppService
    {

        private readonly ITransactionService _transactionService;
        private readonly ICardService _cardService;
        private readonly ICodeVerifyService _codeVerifyService;

        public TransactionAppService(ITransactionService transactionService , ICardService cardService , ICodeVerifyService codeVerifyService)
        {
            _cardService = cardService;
            _transactionService = transactionService;
            _codeVerifyService = codeVerifyService;
        }

        public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
            => _transactionService.GetListOfTransactions(cardNumber);

        public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount, string code)
        {
            var isSuccess = false;
            float fee = 0;

            if (amount > 1000)
            {
                fee = (float)(1.5 * amount) / 100;
            }
            else
            {
                fee = (float)(0.5 * amount) / 100;
            }

            if (amount == 0)
                return "The transfer amount must be greater than 0";

            if (sourceCardNumber.Length < 16 || sourceCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (destinationCardNumber.Length < 16 || destinationCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (!_cardService.CardIsActive(sourceCardNumber))
                return "sourceCardNumber is not valid";

            if (!_cardService.CardIsActive(destinationCardNumber))
                return "destinationCardNumber is not valid";


            var sourceCard = _cardService.GetCardBy(sourceCardNumber);
            var destinationCard = _cardService.GetCardBy(destinationCardNumber);

            if (sourceCard.Balance <= amount + fee)
                return "your card doesn't have enough balance for this transaction";

            //if ((_transactionRepository.DailyWithdrawal(sourceCardNumber) + amount) > 250)
            //    return "Your daily transfer limit is full";
            if (_codeVerifyService.GetCode().Code != code)
                return "Verify Code Is Not Correct";
            if (_codeVerifyService.GetCode().date.AddSeconds(120) < DateTime.Now)
                return "Code is Disable";

            try
            {
                _cardService.Withdraw(sourceCardNumber, amount + fee);
                _cardService.Deposit(destinationCardNumber, amount);
                _cardService.SaveChanges();
                isSuccess = true;

            }
            catch (Exception e)
            {
                isSuccess = false;
                return "Transfer money failed";
            }
            finally
            {
                var transaction = new App.Domain.Core.Quiz2.Transaction.Entities.Transaction()
                {
                    SourceCardNumber = sourceCard.CardNumber,
                    DestinationCardNumber = destinationCard.CardNumber,
                    Amount = amount,
                    ActionAt = DateTime.Now,
                    IsSuccess = isSuccess
                };

                _transactionService.Add(transaction);
            }
            return "The money transfer operation was successful";
        }

       

    }
}
