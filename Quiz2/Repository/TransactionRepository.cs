using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts;
using Quiz2.Dtos;
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
            _appDbContext.Transactions.Add(transaction);
            _appDbContext.SaveChanges();
        }

        public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
        {
            return _appDbContext.Transactions
                .Where(x => x.SourceCard.CardNumber == cardNumber || x.DestinationCard.CardNumber == cardNumber)
                .Select(x => new GetTransactionsDto
                {
                    SourceCardNumber = x.SourceCard.CardNumber,
                    DestinationsCardNumber = x.DestinationCard.CardNumber,
                    ActionAt = x.ActionAt,
                    Amount = x.Amount,
                    IsSuccess = x.IsSuccess,
                }).ToList();
        }

        public float DailyWithdrawal(string cardNumber)
        {
            var amountOfTransactions = _appDbContext.Transactions
                .Where(x => x.ActionAt.Date == DateTime.Now.Date && x.SourceCard.CardNumber == cardNumber && x.IsSuccess == true)
                .Sum(x => x.Amount);

            return amountOfTransactions;
        }
       
    }
}
