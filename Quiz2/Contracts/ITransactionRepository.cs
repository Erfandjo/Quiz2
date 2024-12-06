using Quiz2.Dtos;
using System.Transactions;

namespace Quiz2.Contracts
{
    public interface ITransactionRepository
    {
        List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
        float DailyWithdrawal(string cardNumber);
        void Add(Entities.Transaction transaction);
    }
}
