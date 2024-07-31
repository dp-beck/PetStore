using PetStore;
using System.ComponentModel;
using System.Text.Json;

var productLogic = new ProductLogic();
string userInput = String.Empty;

Console.WriteLine("Press 1 to add a cat food product.");
Console.WriteLine("Press 2 to review a specific cat food product in inventory.");
Console.WriteLine("Type 'exit' to quit.");

userInput = Console.ReadLine()!;
while (userInput is not null && userInput.ToLower() != "exit")
{
    if (userInput == "1")
    { 
        CatFood catFood = new CatFood();
        bool validInput = false;
        
        Console.WriteLine("What is the name of the cat food?");
        catFood.Name = Console.ReadLine()!;

        do
        {
            Console.WriteLine("What is the price of one bag of the cat food?");
            decimal parsedPrice;
            validInput = decimal.TryParse(Console.ReadLine(), out parsedPrice);
            if (validInput)
                catFood.Price = parsedPrice;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a number.");
        } while (!validInput);

        do
        {
            Console.WriteLine("How many bags of cat food are you adding?");
            int parsedQuantity;
            validInput = int.TryParse(Console.ReadLine(), out parsedQuantity);
            if (validInput)
                catFood.Quantity = parsedQuantity;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a whole number.");
        } while (!validInput);
        
        Console.WriteLine("Please describe the cat food.");
        catFood.Description = Console.ReadLine()!;

        do
        {
            Console.WriteLine("How much does a bag of cat food weigh in pounds?");
            double parsedWeightPounds;
            validInput = double.TryParse(Console.ReadLine(), out parsedWeightPounds);
            if (validInput)
                catFood.WeightPounds = parsedWeightPounds;
            else
                Console.WriteLine("Invalid input. Please provide your answer as a number.");
        } while (!validInput);

        Console.WriteLine("If this is kitten food, type 't,' otherwise we assume it is not.");
        if (Console.ReadLine() == "t")
            catFood.IsKittenFood = true;
        else
            catFood.IsKittenFood = false;

        productLogic.AddProduct(catFood);
        Console.WriteLine($"Your catfood, {catFood.Name}, has been added to the inventory.");
    }
    // add a new option for the user. It will be option number 2 and will let them get a specific object out of the list. 
    if (userInput == "2")
    {
        Console.WriteLine("Which cat food product would you like to view? Please specify by name.");
        string nameInput = Console.ReadLine();

        CatFood catFoodToDisplay;
        if (productLogic.IsProductInCatFoodDictionary(nameInput))
        {
            catFoodToDisplay = productLogic.GetCatFoodByName(nameInput);
            Console.WriteLine(JsonSerializer.Serialize(catFoodToDisplay));
        }
        else
        {
            Console.WriteLine("Sorry, that product is not in the inventory.");
        }    
    }
    Console.WriteLine();
    Console.WriteLine("Press 1 to add a product.");
    Console.WriteLine("Press 2 to review a specific cat food product in inventory.");
    Console.WriteLine("Type 'exit' to quit.");
    userInput = Console.ReadLine()!;
}