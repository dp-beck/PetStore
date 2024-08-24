using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class UILogic
    {
        public static void DisplayOptions()
        {
            Console.WriteLine("Press 1 to add a dog leash product.");
            Console.WriteLine("Press 2 to review a specific dog leash product in inventory.");
            Console.WriteLine("Press 8 to view ALL Products.");
            Console.WriteLine("Press 9 to view only IN STOCK products.");
            Console.WriteLine("Press 10 to view only OUT OF STOCK products.");
            Console.WriteLine("Type 'exit' to quit.");
        }

        public static DogLeash GetUserInputForNewDogLeash()
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
            return dogLeash;
        }
        
    }
}
