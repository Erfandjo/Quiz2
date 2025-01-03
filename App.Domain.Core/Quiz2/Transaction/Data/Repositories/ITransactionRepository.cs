using App.Domain.Core.Quiz2.Transaction.DTOs;
using System.Transactions;

namespace App.Domain.Core.Quiz2.Transaction.Data.Repositories
{
    public interface ITransactionRepository
    {
        List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
        float DailyWithdrawal(string cardNumber);
        void Add(Entities.Transaction transaction);
    }
}
