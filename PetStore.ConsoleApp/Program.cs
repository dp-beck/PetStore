using Microsoft.Extensions.DependencyInjection;
using PetStore;
using PetStore.Data;
using System.ComponentModel;
using System.Text.Json;

var services = CreateServiceCollection();
var productLogic = services.GetService<IProductLogic>();
var productRepository = services.GetService<IProductRepository>();
var uiLogic = new UILogic();
string userInput = String.Empty;

uiLogic.DisplayOptions();
userInput = Console.ReadLine()!;

while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Product product = UILogic.GetUserInputForNewProduct();
        productRepository.AddProduct(product);
        Console.WriteLine($"Product added: ");
        UILogic.DisplayProduct(product);
    }

    if (userInput == "2")
    {
        Product? productToDisplay = productRepository.GetProductById(UILogic.GetInputToViewSpecificProduct());
        UILogic.DisplayProduct(productToDisplay);
        
    }

    if (userInput == "8")
       UILogic.DisplayProductsNames(productRepository.GetAllProducts());
    
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
        .AddTransient<IProductLogic, ProductLogic>()
        .AddTransient<IProductRepository, ProductRepository>()
        .BuildServiceProvider();
}