using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class UILogic
    {
        private MenuOptions _MenuOptions { get; set; } = new MenuOptions();
        public void DisplayOptions()
        {
            foreach (string option in _MenuOptions.Options.Values)
            {
                Console.WriteLine(option);
            }
        }

        public static DogLeash GetUserInputForNewDogLeash()
        {
            DogLeash dogLeash = new DogLeash();

            Console.WriteLine("What is the name of the dog leash?");
            dogLeash.Name = Console.ReadLine()!;

            bool validInput = false;
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

        public static string GetInputToViewSpecificDogLeash()
        {
            Console.WriteLine("Enter dog leash name.");
            string nameInput = Console.ReadLine();
            return nameInput;
        }

        public static void DisplayDogLeash(DogLeash dogLeashToDisplay)
        {
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

        public static void DisplayProductsNames(List<Product> products)
        {
            products.ForEach(product => Console.WriteLine(product.Name));
        }

    }
}
