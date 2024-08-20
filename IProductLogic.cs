using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<String> GetOnlyInStockProducts();
        List<String> GetOutOfStockProducts();
        DogLeash GetDogLeashByName(string name);

    }
}
