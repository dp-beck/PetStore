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

        public void AddProduct(Product product)
        {
            _ProductContext.Add(product);
            _ProductContext.SaveChanges();    
        }

        public List<Product> GetAllProducts()
        {
            return _ProductContext.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _ProductContext.Products.Where(p => p.Id == productId).FirstOrDefault()!;
        }
    }
}