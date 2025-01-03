using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.CodeVerify.Data.Repositories;
using App.Domain.Core.Quiz2.Transaction.Data.Repositories;
using App.Domain.Core.Quiz2.Transaction.DTOs;
using App.Domain.Core.Quiz2.Transaction.Services;
using App.Infra.Data.Repos.Ef.Quiz2.Card;
using App.Infra.Data.Repos.Ef.Quiz2.Transaction;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify.Repositories;

namespace App.Domain.Services.Quiz2.Transaction
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        
       

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Add(Core.Quiz2.Transaction.Entities.Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public float DailyWithdrawal(string cardNumber)
        {
            return _transactionRepository.DailyWithdrawal(cardNumber);
        }

        public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
        {
            return _transactionRepository.GetListOfTransactions(cardNumber);
        }
    }
}
