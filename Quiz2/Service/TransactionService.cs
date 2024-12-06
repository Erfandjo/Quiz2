using Quiz2.Contracts;
using Quiz2.Dtos;
using Quiz2.Entities;
using Quiz2.Repository;

namespace Quiz2.Service
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ICodeVerifyRepository _codeVerifyRepository;

        public TransactionService()
        {
            _cardRepository = new CardRepository();
            _transactionRepository = new TransactionRepository();
            _codeVerifyRepository = new CodeVerifyRepository();
        }

        public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
            => _transactionRepository.GetListOfTransactions(cardNumber);

        public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount , string code)
        {
            var isSuccess = false;
            float fee = 0;

            if (amount == 0)
                return "The transfer amount must be greater than 0";

            if (sourceCardNumber.Length < 16 || sourceCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (destinationCardNumber.Length < 16 || destinationCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (!_cardRepository.CardIsActive(sourceCardNumber))
                return "sourceCardNumber is not valid";

            if (!_cardRepository.CardIsActive(destinationCardNumber))
                return "destinationCardNumber is not valid";


            var sourceCard = _cardRepository.GetCardBy(sourceCardNumber);
            var destinationCard = _cardRepository.GetCardBy(destinationCardNumber);

            if (sourceCard.Balance <= amount)
                return "your card doesn't have enough balance for this transaction";

            //if ((_transactionRepository.DailyWithdrawal(sourceCardNumber) + amount) > 250)
            //    return "Your daily transfer limit is full";
            if (_codeVerifyRepository.GetCode().Code != code)
                return "Verify Code Is Not Correct";
            if (_codeVerifyRepository.GetCode().date.AddMinutes(5) < DateTime.Now)
                return "Code is Disable";
            
            try
            {
                if(amount > 1000)
                {
                    fee = (float) (1.5 * amount) / 100;
                } else
                {
                    fee = (float) (0.5 * amount) / 100;
                }

                _cardRepository.Withdraw(sourceCardNumber, amount + fee);
                _cardRepository.Deposit(destinationCardNumber, amount);
                _cardRepository.SaveChanges();
                isSuccess = true;

            }
            catch (Exception e)
            {
                isSuccess = false;
                return "Transfer money failed";
            }
            finally
            {
                var transaction = new Entities.Transaction()
                {
                    SourceCardNumber = sourceCard.CardNumber,
                    DestinationCardNumber = destinationCard.CardNumber,
                    Amount = amount,
                    ActionAt = DateTime.Now,
                    IsSuccess = isSuccess
                };

                _transactionRepository.Add(transaction);
            }
            return "The money transfer operation was successful";
        }

        public void GenerateCode()
        {
            Random random = new Random();
            var result = Convert.ToString(random.Next(random.Next(10000 , 99999)));
            _codeVerifyRepository.Add(result);
        }

    }
}
