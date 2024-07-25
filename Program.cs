using PetStore;
using System.ComponentModel;
using System.Text.Json;

string userInput = String.Empty;

Console.WriteLine("Press 1 to add a cat food product.");
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

        string catFoodString = JsonSerializer.Serialize(catFood);
        Console.WriteLine();
        Console.WriteLine(catFoodString);
    }

    Console.WriteLine("");
    Console.WriteLine("Press 1 to add a product.");
    Console.WriteLine("Type 'exit' to quit.");
    userInput = Console.ReadLine()!;
}