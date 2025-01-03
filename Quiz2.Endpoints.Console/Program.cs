using Microsoft.SqlServer.Server;

using ConsoleTables;

using App.Domain.Core.Quiz2.Card.Services;
using App.Domain.Core.Quiz2.Transaction.DTOs;
using App.Domain.Core.Quiz2.Result;
using App.Domain.Core.Quiz2.Transaction.Services;
using App.Domain.AppServices.Quiz2.Card;
using App.Domain.AppServices.Quiz2.Transaction;
using App.Domain.Core.Quiz2.Card.AppServices;
using App.Domain.Core.Quiz2.Transaction.AppServices;
using App.Domain.Core.Quiz2.CodeVerify.AppServices;
using App.Domain.AppServices.Quiz2.CodeVerify;

//ICardAppService cardAppService = new CardAppService();
//ITransactionAppService transactionAppService = new TransactionAppService();
//ICodeVerifyAppService codeVerifyAppService = new CodeVerifyAppService();
//Result passwordValidationResult;
//string cardNumber;
//string destinationCardNumber;
//float amount;



//do
//{
//    Console.Clear();

//    Console.Write("CardNumber : ");
//    cardNumber = Console.ReadLine();

//    Console.Write("Password : ");
//    var password = Console.ReadLine();

//    passwordValidationResult = cardAppService.PasswordIsValid(cardNumber, password);

//    Console.WriteLine(passwordValidationResult.Message);
//    Console.ReadKey();

//} while (!passwordValidationResult.IsSucces);

//while (true)
//{
//    Console.Clear();

//    Console.WriteLine("1.Transfer Money");
//    Console.WriteLine("2.Show Transactions");
//    Console.WriteLine("3.Show Balance");
//    Console.WriteLine("4.Change Password");

//    var selectedItem = Console.ReadKey();

//    Console.Clear();

//    var sourceCardNumber = cardNumber;
//    Console.WriteLine($"Source CardNumber Is {cardNumber} ");
//    Console.WriteLine();

//    switch (selectedItem.KeyChar)
//    {
//        case '1':
//            {
//                TransferMoney(sourceCardNumber);
//                break;
//            }
//        case '2':
//            {
//                ShowListOfTransactions();
//                break;
//            }
//        case '3':
//            var balance = cardAppService.GetBalance(cardNumber);
//            Console.WriteLine($"Balance is {(float)balance}");
//            Console.ReadKey();
//            break;
//        case '4':
//            ChangePassword();
//            break;
//    }
//}

//void TransferMoney(string sourceCardNumber)
//{
//    Console.Write("Please Insert Destination CardNumber : ");
//    destinationCardNumber = Console.ReadLine();

//    Console.Write("Amount : ");

//    amount = float.Parse(Console.ReadLine() ?? string.Empty);
//    Console.Clear();
//    var resultDisplay = cardAppService.DisplayInformationTransfer(destinationCardNumber, amount);

//    Console.WriteLine(resultDisplay.Message);

//    if (resultDisplay.IsSucces)
//    {
//        Console.WriteLine("1)Yes , 2)No");
//        int option = Convert.ToInt32(Console.ReadLine() ?? string.Empty);
//        switch (option)
//        {
//            case 1:
//                Console.Clear();
//                codeVerifyAppService.GenerateCode();
//                Console.Write("Please Enter Code : ");
//                string code = Console.ReadLine();
//                var transactionStatus = transactionAppService.TransferMoney(sourceCardNumber, destinationCardNumber, amount, code);

//                Console.WriteLine(transactionStatus);

//                Console.ReadKey();
//                break;
//            case 2:
//                Console.WriteLine("Ok!");
//                Console.ReadKey();
//                break;
//        }
//    }



//}
//void ShowListOfTransactions()
//{
//    var transactions = transactionAppService.GetListOfTransactions(cardNumber);

//    ConsoleTable
//        .From<GetTransactionsDto>(transactions)
//        .Configure(o => o.NumberAlignment = Alignment.Right)
//        .Write(ConsoleTables.Format.Minimal);

//    Console.ReadKey();
//}
//void ChangePassword()
//{
//    Console.Write("Please Enter new Password : ");
//    string newpass = Console.ReadLine();
//    cardAppService.ChangePassword(cardNumber, newpass);
//}

