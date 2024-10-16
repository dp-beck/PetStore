using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ProductContext;
        public ProductRepository()
        {
            _ProductContext = new ProductContext();
        }

        public async void AddProduct(Product product)
        {
            _ProductContext.Add(product);
            await _ProductContext.SaveChangesAsync();    
        }

        public List<Product> GetAllProducts()
        {
            return _ProductContext.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _ProductContext.Products.Where(p => p.ProductId == productId).FirstOrDefault()!;
        }

        public async void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            _ProductContext.Remove(product);
            await _ProductContext.SaveChangesAsync();
        }
    }
}