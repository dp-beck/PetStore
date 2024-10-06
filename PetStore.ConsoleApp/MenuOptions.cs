using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class MenuOptions
    {
        public Dictionary<string, string> Options { get; private set; }
        public MenuOptions()
        {
            Options = new Dictionary<string, string>
            {
                { "1", "Press 1 to add a new product." },
                { "2", "Press 2 to review a specific product in inventory." },
                { "3", "Press 3 to add a new order."},
                { "8", "Press 8 to view ALL Products."},
                { "9",  "NOT WORKING: Press 9 to view only IN STOCK products."},
                { "10", "NOT WORKING: Press 10 to view only OUT OF STOCK products." },
                { "exit", "Type 'exit' to quit." }
            };

        }
    }
}
