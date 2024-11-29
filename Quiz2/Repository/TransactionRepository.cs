using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts;
using Quiz2.Infrastructure;
using System.Transactions;

namespace Quiz2.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public void Add(Entities.Transaction transaction)
        {
            var transactionn = new Entities.Transaction()
            {
                Amount = transaction.Amount,
                DestinationCardNumber = transaction.DestinationCardNumber,
                SourceCardNumber = transaction.SourceCardNumber,
                TransactionDate = transaction.TransactionDate,
                isSuccessful = transaction.isSuccessful,

            };
            _appDbContext.Transactions.Add(transactionn);
            _appDbContext.SaveChanges();
        }

        public List<Entities.Transaction> GetTransactions(string CardNumber)
        {
            var transactionList = _appDbContext.Transactions.AsNoTracking().Where(x => x.SourceCardNumber == CardNumber || x.DestinationCardNumber == CardNumber).ToList();
            return transactionList;
        }
    }
}
