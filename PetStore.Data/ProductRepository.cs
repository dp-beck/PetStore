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

        public void AddProduct(ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntity> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetProductEntityById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}