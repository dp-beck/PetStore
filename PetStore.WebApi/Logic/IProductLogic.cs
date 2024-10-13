using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Data;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<Product> GetOnlyInStockProducts();
        List<Product> GetOutOfStockProducts();
        Product GetProductById(int productId);
    }
}
