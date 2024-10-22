using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ProductContext;
        public ProductRepository()
        {
            _ProductContext = new ProductContext();
        }

        public async Task AddProductAsync(Product product)
        {
            _ProductContext.Add(product);
            await _ProductContext.SaveChangesAsync();    
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _ProductContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ProductContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync()!;
        }

        public  async Task DeleteProductAsync(int productId)
        {
            var product = await GetProductByIdAsync(productId);
            _ProductContext.Remove(product);
            await _ProductContext.SaveChangesAsync();
        }
    }
}