using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using PetStore.Data;
using PetStore.Validators;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateAndThrow(product);
            
            _productRepository.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int productID) 
        {
            try
            {
                return _productRepository.GetProductById(productID);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        

        public List<Product> GetOnlyInStockProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetOutOfStockProducts()
        {
            throw new NotImplementedException();
        } 
    }
}
