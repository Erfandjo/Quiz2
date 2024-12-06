using Quiz2.Dtos;

namespace Quiz2.Contracts
{
    public interface ITransactionService
    {
        string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount , string code);
        List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
        public void GenerateCode();
    }
}
