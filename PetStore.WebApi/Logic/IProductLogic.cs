using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Data;

namespace PetStore.WebApi.Logic
{
    public interface IProductLogic
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        List<Product> GetOnlyInStockProducts();
        List<Product> GetOutOfStockProducts();
        Task<Product> GetProductByIdAsync(int productId);
        Task DeleteProductAsync(int productId);
    }
}
