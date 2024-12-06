// See https://aka.ms/new-console-template for more information
using Microsoft.SqlServer.Server;
using Quiz2.Contracts;
using Quiz2;
using Quiz2.CurrentUser;
using ConsoleTables;
using Quiz2.Dtos;
using Quiz2.Entities;
using Quiz2.Infrastructure;
using Quiz2.Repository;
using Quiz2.Service;

ICardService cardService = new CardService();
ITransactionService transactionService = new TransactionService();
Result passwordValidationResult;
string cardNumber;
string destinationCardNumber;
float amount;



do
{
    Console.Clear();

    Console.Write("CardNumber : ");
    cardNumber = Console.ReadLine();

    Console.Write("Password : ");
    var password = Console.ReadLine();

    passwordValidationResult = cardService.PasswordIsValid(cardNumber, password);

    Console.WriteLine(passwordValidationResult.Message);
    Console.ReadKey();

} while (!passwordValidationResult.IsSucces);

while (true)
{
    Console.Clear();

    Console.WriteLine("1.Transfer Money");
    Console.WriteLine("2.Show Transactions");
    Console.WriteLine("3.Show Balance");
    Console.WriteLine("4.Change Password");

    var selectedItem = Console.ReadKey();

    Console.Clear();

    var sourceCardNumber = cardNumber;
    Console.WriteLine($"Source CardNumber Is {cardNumber} ");
    Console.WriteLine();

    switch (selectedItem.KeyChar)
    {
        case '1':
            {
                TransferMoney(sourceCardNumber);
                break;
            }
        case '2':
            {
                ShowListOfTransactions();
                break;
            }
        case '3':
            var balance = cardService.GetBalance(cardNumber);
            Console.WriteLine($"Balance is {(float) balance}");
            Console.ReadKey();
            break;
        case '4':
            ChangePassword();
            break;
    }
}

void TransferMoney(string sourceCardNumber)
{
    Console.Write("Please Insert Destination CardNumber : ");
    destinationCardNumber = Console.ReadLine();

    Console.Write("Amount : ");

     amount = float.Parse(Console.ReadLine() ?? string.Empty);
    Console.Clear();
    var resultDisplay = cardService.DisplayInformationTransfer(destinationCardNumber, amount);

    Console.WriteLine(resultDisplay.Message);

    if (resultDisplay.IsSucces)
    {
        Console.WriteLine("1)Yes , 2)No");
        int option = Convert.ToInt32(Console.ReadLine() ?? string.Empty);
        switch (option)
        {
            case 1:
                Console.Clear();
                transactionService.GenerateCode();
                Console.Write("Please Enter Code : ");
                string code = Console.ReadLine();
                var transactionStatus = transactionService.TransferMoney(sourceCardNumber, destinationCardNumber, amount , code);

                Console.WriteLine(transactionStatus);

                Console.ReadKey();
                break;
                case 2:
                Console.WriteLine("Ok!");
                Console.ReadKey();
                break;
        }
    }
  

  
}
void ShowListOfTransactions()
{
    var transactions = transactionService.GetListOfTransactions(cardNumber);

    ConsoleTable
        .From<GetTransactionsDto>(transactions)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(ConsoleTables.Format.Minimal);

    Console.ReadKey();
}
void ChangePassword()
{
    Console.Write("Please Enter new Password : ");
    string newpass = Console.ReadLine();
    cardService.ChangePassword(cardNumber, newpass);
}