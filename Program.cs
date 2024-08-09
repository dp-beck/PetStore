using PetStore;
using System.ComponentModel;
using System.Text.Json;

var productLogic = new ProductLogic();
string userInput = String.Empty;

Console.WriteLine("Press 1 to add a dog leash product.");
Console.WriteLine("Press 2 to review a specific dog leash product in inventory.");
Console.WriteLine("Press 8 to view ALL Products");
Console.WriteLine("Type 'exit' to quit.");

userInput = Console.ReadLine()!;
while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    { 
        DogLeash dogLeash = new DogLeash();
        bool validInput = false;
        
        Console.WriteLine("What is the name of the dog leash?");
        dogLeash.Name = Console.ReadLine()!;

        do
        {
            Console.WriteLine("What is the price of one dog leash?");
            decimal parsedPrice;
            validInput = decimal.TryParse(Console.ReadLine(), out parsedPrice);
            if (validInput)
                dogLeash.Price = parsedPrice;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a number.");
        } while (!validInput);

        do
        {
            Console.WriteLine("How many dog leashes are you adding?");
            int parsedQuantity;
            validInput = int.TryParse(Console.ReadLine(), out parsedQuantity);
            if (validInput)
                dogLeash.Quantity = parsedQuantity;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a whole number.");
        } while (!validInput);
        
        Console.WriteLine("Please describe the dog leash.");
        dogLeash.Description = Console.ReadLine()!;

        do
        {
            Console.WriteLine("How long is the dog leash in inches?");
            int parsedLengthInches;
            validInput = int.TryParse(Console.ReadLine(), out parsedLengthInches);
            if (validInput)
                dogLeash.LengthInches = parsedLengthInches;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a whole number.");
        } while (!validInput);

        Console.WriteLine("What material is the dog leash made of?");
        dogLeash.Material = Console.ReadLine()!;

        productLogic.AddProduct(dogLeash);
        Console.WriteLine($"Product added: Name = {dogLeash.Name}, Material = {dogLeash.Material}.");
    }
    // add a new option for the user. It will be option number 2 and will let them get a specific object out of the list. 
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
            Console.WriteLine(JsonSerializer.Serialize(dogLeashToDisplay));
        }
        
    }

    if (userInput == "8")
    {
        var allProducts = productLogic.GetAllProducts();
        foreach (var product in allProducts)
        {
            Console.WriteLine(product.Name);
        }
    }

    Console.WriteLine();
    Console.WriteLine("Press 1 to add a product.");
    Console.WriteLine("Press 2 to review a specific dog leash product in inventory.");
    Console.WriteLine("Press 8 to view ALL Products");
    Console.WriteLine("Type 'exit' to quit.");
    userInput = Console.ReadLine()!;
}