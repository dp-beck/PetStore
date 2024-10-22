using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        public Task AddProductAsync(Product product);
        
        public Task<Product> GetProductByIdAsync(int productId);
        
        public Task<List<Product>> GetAllProductsAsync();

        public Task DeleteProductAsync(int productId);

    }
}