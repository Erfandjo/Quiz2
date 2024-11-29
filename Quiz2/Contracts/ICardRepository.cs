using Quiz2.Entities;

namespace Quiz2.Contracts
{
    public interface ICardRepository
    {
        void Transfer(string sourceCardNumber , string destinationCardNumber , float transferAmount);
        Card? GetCard(string cardNumber);
        void InActiveCard(string cartNumber);
        bool Login(string cardNumber , string password);
    }
}
