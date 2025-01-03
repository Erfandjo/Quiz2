using App.Domain.AppServices.Quiz2.Card;
using App.Domain.AppServices.Quiz2.CodeVerify;
using App.Domain.AppServices.Quiz2.Transaction;
using App.Domain.Core.Quiz2.Card.AppServices;
using App.Domain.Core.Quiz2.CodeVerify.AppServices;
using App.Domain.Core.Quiz2.Transaction.AppServices;
using App.Infra.Data.Db.Storage.Memory;
using Microsoft.AspNetCore.Mvc;
using Quiz2.Endpoints.MVC.Models;

namespace Quiz2.Endpoints.MVC.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransactionAppService _transactionAppService;
        private readonly ICardAppService _cardAppService;
        private readonly ICodeVerifyAppService _codeVerifyAppService;
        



        public TransactionController(ITransactionAppService transactionAppService , ICardAppService cardAppService , ICodeVerifyAppService codeVerifyAppService)
        {
            _transactionAppService = transactionAppService;
            _cardAppService = cardAppService;
            _codeVerifyAppService = codeVerifyAppService;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Transfer()
        {
            if (CurrentUser.OnlineUser is not null)
            {
                return View(CurrentUser.OnlineUser);
            }
            return RedirectToAction("Login", "Card");
        }
        public IActionResult TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount, string codeVerify)
        {
            if (CurrentUser.OnlineUser is not null)
            {
                _transactionAppService.TransferMoney(sourceCardNumber, destinationCardNumber, amount, codeVerify);
                return RedirectToAction("Index" , "Home");
            }
            return RedirectToAction("Login", "Card");
        }

        public IActionResult DisplayInformationTransfer(string destinationCardNumber, float amount)
        {
            if (CurrentUser.OnlineUser is not null)
            {
                if (destinationCardNumber is not null)
                {
                    ShowInformation.SourceCardNumber = CurrentUser.OnlineUser.CardNumber;
                    ShowInformation.DestinationsCard = _cardAppService.GetbyCardNumber(destinationCardNumber);
                    ShowInformation.Amount = amount;
                }
                ShowInformationViewModel showInformationViewModel = new ShowInformationViewModel()
                {
                    SourceCardNumber = ShowInformation.SourceCardNumber,
                    DestinationsCard = ShowInformation.DestinationsCard,
                    Amount = ShowInformation.Amount
                };
                    return View(showInformationViewModel);
                
            }
            return RedirectToAction("Login", "Card");
        }


        public IActionResult ShowTransaction()
        {
            if (CurrentUser.OnlineUser is not null)
            {
                var transaction = _transactionAppService.GetListOfTransactions(CurrentUser.OnlineUser.CardNumber);
                return View(transaction);
            }
            return RedirectToAction("Login", "Card");
        }
        

        public IActionResult GenerateCode()
        {
            if (CurrentUser.OnlineUser is not null)
            {
                _codeVerifyAppService.GenerateCode();
                return RedirectToAction("DisplayInformationTransfer");
            }
            return RedirectToAction("Login", "Card");
        }
    }
}
