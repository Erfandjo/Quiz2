using System.Transactions;

namespace Quiz2.Contracts
{
    public interface ITransactionRepository
    {
        List<Entities.Transaction> GetTransactions(string CardNumber);
        void Add(Entities.Transaction transaction);
    }
}
