using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PetStore.Data;

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

        public static Product GetUserInputForNewProduct()
        {
            Console.WriteLine("Please add a product in JSON format.");
            string userInputAsJson = Console.ReadLine()!;
            Product? product = JsonSerializer.Deserialize<Product>(userInputAsJson);
            return product!;
        }

        public static int GetInputToViewSpecificProduct()
        {
            Console.WriteLine("Enter product ID.");
            string IdInput = Console.ReadLine();
            int Id = int.Parse(IdInput);
            return Id;
        }

        public static void DisplayProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Sorry, that product is not in the inventory.");
            }
            else
            {
                Console.WriteLine($"Product Name= {product.Name}, Quantity= {product.Quantity}");
                Console.WriteLine($"Price= {product.Price}, Description= {product.Description}");
            }
        }

        public static void DisplayProductsNames(List<Product> products)
        {
            products.ForEach(product => Console.WriteLine(product.Name));
        }

    }
}
