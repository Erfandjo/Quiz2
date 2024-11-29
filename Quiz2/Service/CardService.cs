using Quiz2.Contracts;
using Quiz2.Repository;
using System.Transactions;

namespace Quiz2.Service
{
    public class CardService : ICardService
    {
        ICardRepository _cardRepository;
        ITransactionRepository _transactionRepository;
        public int TryLogin { get; set; }
        public float transferMoney { get; set; }

        public CardService()
        {
            _cardRepository = new CardRepository();
            _transactionRepository = new TransactionRepository();
        }

        public void CheckTryLogin(string cardNumber)
        {
            TryLogin++;
            if (TryLogin == 3)
            {
                _cardRepository.InActiveCard(cardNumber);
            }
        }

        public Result Login(string cardNumber, string password)
        {
            CheckTryLogin(cardNumber);
            var card = _cardRepository.GetCard(cardNumber);
            if (_cardRepository.Login(cardNumber, password))
            {
                CurrentUser.CurrentUser.OnlineUser = card;
                return new Result(true, "Success");
            }
            return new Result(false, "UserName or Password Incorrect.");
        }

        public Result Transfer(string sourceCardNumber, string destinationCardNumber, float transferAmount)
        {
            var sourceCard = _cardRepository.GetCard(sourceCardNumber);
            var destinationCard = _cardRepository.GetCard(destinationCardNumber);
            if (CurrentUser.CurrentUser.OnlineUser.CardNumber == sourceCardNumber)
            {
                if (transferAmount <= 250)
                {
                    if (sourceCard is not null)
                    {
                        if (destinationCard is not null)
                        {
                            if (sourceCard.IsActive)
                            {
                                if (CheckTransfer(sourceCardNumber).IsSucces)
                                {
                                    if (sourceCard.Balance >= transferAmount)
                                    {
                                        _cardRepository.Transfer(sourceCardNumber, destinationCardNumber, transferAmount);
                                        Entities.Transaction transaction = new Entities.Transaction()
                                        {
                                            Amount = transferAmount,
                                            DestinationCardNumber = destinationCardNumber,
                                            SourceCardNumber = sourceCardNumber,
                                            TransactionDate = DateTime.Now,
                                            isSuccessful = true,
                                        };
                                        _transactionRepository.Add(transaction);
                                        return new Result(true, "Success");
                                    }
                                    else
                                    {

                                        Entities.Transaction transaction2 = new Entities.Transaction()
                                        {
                                            Amount = transferAmount,
                                            DestinationCardNumber = destinationCardNumber,
                                            SourceCardNumber = sourceCardNumber,
                                            TransactionDate = DateTime.Now,
                                            isSuccessful = false,
                                        };
                                        _transactionRepository.Add(transaction2);
                                        return new Result(false, "Insufficient inventory");
                                    }
                                }
                                else
                                {
                                    Entities.Transaction transaction3 = new Entities.Transaction()
                                    {
                                        Amount = transferAmount,
                                        DestinationCardNumber = destinationCardNumber,
                                        SourceCardNumber = sourceCardNumber,
                                        TransactionDate = DateTime.Now,
                                        isSuccessful = false,
                                    };
                                    _transactionRepository.Add(transaction3);
                                    return new Result(false, "Card is Not Active");
                                }
                            }
                            else
                            {
                                return new Result(false, "Destination Card Not Found");
                            }

                        }
                        else
                        {
                            return new Result(false, "Source Card Not Found");
                        }
                    }
                    else
                    {
                        return new Result(false, CheckTransfer(sourceCardNumber).Message);
                    }
                }
                else
                {
                    return new Result(false, "Not Access");
                }
            }
            else
            {
                return new Result(false, "indicating the transfer limit has been exceeded");
            }



        }

        public Result CheckTransfer(string cardNumber)
        {
            transferMoney = 0;
            var transaction = _transactionRepository.GetTransactions(cardNumber);
            foreach (var tr in transaction)
            {
                if (tr.TransactionDate.Day == DateTime.Now.Day)
                {
                    transferMoney += tr.Amount;
                }
            }
            if (transferMoney < 250)
            {
                return new Result(true);
            }
            return new Result(false, "transfer limit has been exceeded");
        }
    }
}
