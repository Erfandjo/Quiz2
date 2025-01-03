using App.Domain.Core.Quiz2.Transaction.DTOs;

namespace App.Domain.Core.Quiz2.Transaction.Services
{
    public interface ITransactionService
    {
        List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
        float DailyWithdrawal(string cardNumber);
        void Add(Entities.Transaction transaction);
    }
}
