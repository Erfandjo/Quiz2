using App.Domain.Core.Quiz2.Transaction.DTOs;

namespace App.Domain.Core.Quiz2.Transaction.AppServices
{
    public interface ITransactionAppService
    {
        string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount, string code);
        List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
    }
}
