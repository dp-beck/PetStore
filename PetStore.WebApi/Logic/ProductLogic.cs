using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using PetStore.Data;
using PetStore.Validators;

namespace PetStore.WebApi.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateAndThrow(product);

            await _productRepository.AddProductAsync(product);        
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
             return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productID) 
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(productID);
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

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
