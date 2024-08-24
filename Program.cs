using PetStore;
using System.ComponentModel;
using System.Text.Json;

var productLogic = new ProductLogic();
string userInput = String.Empty;

UILogic.DisplayOptions();
userInput = Console.ReadLine()!;
while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        var dogLeash = UILogic.GetUserInputForNewDogLeash();
        productLogic.AddProduct(dogLeash);
        Console.WriteLine($"Product added: Name = {dogLeash.Name}, Material = {dogLeash.Material}.");
    }

    if (userInput == "2")
    {
        Console.WriteLine("Enter dog leash name.");
        string nameInput = Console.ReadLine();

        DogLeash dogLeashToDisplay = productLogic.GetDogLeashByName(nameInput);
        if (dogLeashToDisplay == null)
        {
            Console.WriteLine("Sorry, that product is not in the inventory.");
        }
        else
        {
            Console.WriteLine($"Product Name= {dogLeashToDisplay.Name}, Material= {dogLeashToDisplay.Material}");
            Console.WriteLine($"Price= {dogLeashToDisplay.Price}, Discounted Price= {dogLeashToDisplay.Price.DiscountThisPrice()}");
        }
        
    }

    if (userInput == "8")
        productLogic.GetAllProducts().ForEach(product => Console.WriteLine(product.Name));
    
    if (userInput == "9")
        productLogic.GetOnlyInStockProducts().ForEach(Console.WriteLine);

    if (userInput == "10")
        productLogic.GetOutOfStockProducts().ForEach(Console.WriteLine);

    Console.WriteLine();
    UILogic.DisplayOptions();
    userInput = Console.ReadLine()!;
}