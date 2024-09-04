using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
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
            Console.WriteLine("Please add a dog leash in JSON format.");
            string userInputAsJson = Console.ReadLine()!;
            DogLeash? dogLeash = JsonSerializer.Deserialize<DogLeash>(userInputAsJson);
            return dogLeash!;
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
