// See https://aka.ms/new-console-template for more information
using Quiz2.CurrentUser;
using Quiz2.Entities;
using Quiz2.Infrastructure;
using Quiz2.Repository;
using Quiz2.Service;

CardService cardService = new CardService();
TransactionService transactionService = new TransactionService();

while (true)
{
    Login();

    while (CurrentUser.OnlineUser is not null)
    {
        Console.Clear();
        Console.WriteLine("1)Transfer");
        Console.WriteLine("2)Get Transaction");
        Console.Write("Please Select : ");
        var option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                Transfer();
                Console.ReadKey();
                break;

                case 2:
                GetTransactionCard();
                Console.ReadKey();
                break;
        }
    }
}

void Login()
{
    Console.Clear();
    Console.Write("Please Enter Card Number : ");
    var cardNumber = Console.ReadLine();
    Console.Write("Please Enter Password : ");
    var password = Console.ReadLine();
    Console.WriteLine(cardService.Login(cardNumber, password).Message);
    Console.ReadKey();
}
void Transfer()
{
    Console.Write("Please Enter Source Card Number : ");
    var sourceCardNumber = Console.ReadLine();
    Console.Write("Please Enter Destination Card Number : ");
    var destinationCardNumber = Console.ReadLine();
    Console.Write("Please Enter Amount Transfer : ");
    var transfer = Convert.ToInt32(Console.ReadLine());
    if (sourceCardNumber.Length == 16)
    {
        if(destinationCardNumber.Length == 16)
        {
            if (transfer <= 0)
            {
                Console.WriteLine("The transfer amount must be greater than zero");
            }
            else
            {
                Console.WriteLine(cardService.Transfer(sourceCardNumber, destinationCardNumber, transfer).Message);
            }
        }
        else
        {
            Console.WriteLine("Source Card Number must be 16 digits long");
        }
    }
    else
    {
        Console.WriteLine("Destination Card Number must be 16 digits long");
    }
    
    
    
}
void GetTransactionCard()
{
    Console.Write("Please Enter Number Card : ");
    var numberCard = Console.ReadLine();
    if (numberCard.Length == 16)
    {
        transactionService.GetTransactions(numberCard);
    }
    else
    {
        Console.WriteLine("Card numbers must be 16 digits long");
    }
    
}