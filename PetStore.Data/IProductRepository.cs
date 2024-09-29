using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        public void AddProduct(ProductEntity productEntity);
        
        public ProductEntity GetProductEntityById(int productId);
        
        public List<ProductEntity> GetAllProducts();

    }
}