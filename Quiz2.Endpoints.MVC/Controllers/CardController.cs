using App.Domain.AppServices.Quiz2.Card;
using App.Domain.Core.Quiz2.Card.AppServices;
using App.Domain.Core.Quiz2.Card.Entities;
using App.Infra.Data.Db.Storage.Memory;
using Microsoft.AspNetCore.Mvc;

namespace Quiz2.Endpoints.MVC.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardAppService _cardAppService;

        public CardController(ICardAppService cardAppService)
        {
            _cardAppService = cardAppService;
        }
        public IActionResult Index()
        {
            if (CurrentUser.OnlineUser is not null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
       

        public IActionResult GetBalance()
        {
            if(CurrentUser.OnlineUser is not null)
            {
                var balance = _cardAppService.GetBalance(CurrentUser.OnlineUser.CardNumber);
                return View(balance);
            }
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginCard(string cardNumber, string password)
        {
            _cardAppService.PasswordIsValid(cardNumber, password);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangePassword()
        {
            if(CurrentUser.OnlineUser is not null)
            {
                var card = CurrentUser.OnlineUser;
                return View(card);
            }
            return RedirectToAction("Login");
        }

        public IActionResult ChangePasswordCard(string password)
        {
            if (CurrentUser.OnlineUser is not null)
            {
                _cardAppService.ChangePassword(CurrentUser.OnlineUser.CardNumber, password);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

    }
}
