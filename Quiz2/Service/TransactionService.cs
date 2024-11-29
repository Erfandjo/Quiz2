using Quiz2.Contracts;
using Quiz2.Repository;

namespace Quiz2.Service
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _TransactionRepository;

        public TransactionService()
        {
            _TransactionRepository = new TransactionRepository();
        }

        public void GetTransactions(string CardNumber)
        {
            if (CurrentUser.CurrentUser.OnlineUser.CardNumber == CardNumber)
            {
                var list = _TransactionRepository.GetTransactions(CardNumber);
                foreach (var transaction in list)
                {
                    Console.WriteLine($"Source Card Number : {transaction.SourceCardNumber} , Destination Card Number : {transaction.DestinationCardNumber} , Transaction Date : {transaction.TransactionDate} , Is Successful : {transaction.isSuccessful}");
                }
            }
            else
            {
                Console.WriteLine("Not Access");
            }
        }
    }
}
