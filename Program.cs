using Microsoft.Extensions.DependencyInjection;
using PetStore;
using System.ComponentModel;
using System.Text.Json;

var services = CreateServiceCollection();
var productLogic = services.GetService<IProductLogic>();
var uiLogic = new UILogic();
string userInput = String.Empty;

uiLogic.DisplayOptions();
userInput = Console.ReadLine()!;

while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        var dogLeash = UILogic.GetUserInputForNewDogLeash();
        productLogic.AddProduct(dogLeash);
        Console.WriteLine($"Product added: ");
        UILogic.DisplayDogLeash(dogLeash);
    }

    if (userInput == "2")
    {
        DogLeash dogLeashToDisplay = productLogic.GetDogLeashByName(UILogic.GetInputToViewSpecificDogLeash());
        UILogic.DisplayDogLeash(dogLeashToDisplay);
        
    }

    if (userInput == "8")
       UILogic.DisplayProductsNames(productLogic.GetAllProducts());
    
    if (userInput == "9")
       UILogic.DisplayProductsNames(productLogic.GetOnlyInStockProducts());

    if (userInput == "10")
        UILogic.DisplayProductsNames(productLogic.GetOutOfStockProducts());

    Console.WriteLine();
    uiLogic.DisplayOptions();
    userInput = Console.ReadLine()!;
}

static IServiceProvider CreateServiceCollection()
{
   return new ServiceCollection()
        .AddTransient< IProductLogic, ProductLogic>()
        .BuildServiceProvider();
}