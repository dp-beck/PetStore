using Microsoft.Extensions.DependencyInjection;
using PetStore;
using PetStore.ConsoleApp.Logic;
using PetStore.Data;
using PetStore.Data.Models;
using System.ComponentModel;
using System.Text.Json;

var services = CreateServiceCollection();
var productLogic = services.GetService<IProductLogic>();
var orderLogic = services.GetService<IOrderLogic>();
var uiLogic = new UILogic();
string userInput = String.Empty;

uiLogic.DisplayOptions();
userInput = Console.ReadLine()!;

while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Product product = UILogic.GetUserInputForNewProduct();
        productLogic!.AddProduct(product);
        Console.WriteLine($"Product added: ");
        UILogic.DisplayProduct(product);
    }

    if (userInput == "2")
    {
        Product? productToDisplay = productLogic!.GetProductById(UILogic.GetInputToViewSpecificProduct());
        UILogic.DisplayProduct(productToDisplay);
        
    }

    if (userInput == "3")
    {
        Order order = UILogic.GetUserInputForNewOrder();
        orderLogic!.AddOrder(order);
        Console.WriteLine("Order added: ");
        UILogic.DisplayOrder(order);
    }

    if (userInput == "4")
    {
        Order? orderToDisplay = orderLogic!.GetOrderById(UILogic.GetInputToViewSpecificOrder());
        UILogic.DisplayOrder(orderToDisplay);
    }

    if (userInput == "8")
       UILogic.DisplayProductsNames(productLogic!.GetAllProducts());
    
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
        .AddTransient<IOrderLogic, OrderLogic>()
        .AddTransient<IOrderRepository, OrderRepository>()
        .BuildServiceProvider();
}