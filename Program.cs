using PetStore;
using System.ComponentModel;
using System.Text.Json;

Console.WriteLine("Press 1 to add a product.");
Console.WriteLine("Type 'exit' to quit.");
string userInput = Console.ReadLine();
while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        CatFood catFood = new CatFood();
        
        Console.WriteLine("What is the name of the cat food?");
        catFood.Name = Console.ReadLine();

        Console.WriteLine("What is the price of the cat food?");
        catFood.Price = decimal.Parse(Console.ReadLine());
        
        Console.WriteLine("How many bags of cat food are there?");
        catFood.Quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Please describe the cat food.");
        catFood.Description = Console.ReadLine();

        Console.WriteLine("How much does a bag of cat food weigh in pounds?");
        catFood.WeightPounds = double.Parse(Console.ReadLine());

        Console.WriteLine("If this is kitten food, type 't,' otherwise we assume it is not.");
        if (Console.ReadLine() == "t")
            catFood.KittenFood = true;
        else
            catFood.KittenFood = false;

        string catFoodString = JsonSerializer.Serialize(catFood);
        Console.WriteLine(catFoodString);
    }
    
    Console.WriteLine("");
    Console.WriteLine("Press 1 to add a product.");
    Console.WriteLine("Type 'exit' to quit.");
    userInput = Console.ReadLine();
}