using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using PetStore.Validators;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashDictionary;
        private Dictionary<string, CatFood> _catFoodDictionary;

        public ProductLogic()
        {
            _products = new List<Product>();
            _dogLeashDictionary = new Dictionary<string, DogLeash>();
            _catFoodDictionary = new Dictionary<string, CatFood>();
            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99m, Quantity = 5 });
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 45.99m, Quantity = 0 });
        }

        // Polymorphism -- this function does different things depending on whether the
        // the product is a dog leash or cat food.
        public void AddProduct(Product product)
        {
            ProductValidator validator = new ProductValidator();
            validator.ValidateAndThrow(product);
            
            _products.Add(product);
            if (product is DogLeash)
                _dogLeashDictionary.Add(product.Name, (DogLeash)product);
            if (product is CatFood)
                _catFoodDictionary.Add(product.Name, (CatFood)product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public T? GetProductByName<T>(string name) where T : Product
        {
            try
            {
                if (typeof(T) == typeof(DogLeash))
                    return _dogLeashDictionary[name] as T;
                else if(typeof(T) == typeof(CatFood))
                    return _catFoodDictionary[name] as T;
                else   
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CatFood GetCatFoodByName(string name)
        {
            try
            {
                return _catFoodDictionary[name];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Product> GetOnlyInStockProducts()
        {
            var inStockProducts = new List<Product>();
            foreach (var prod in _products)
            {
                if (prod.Quantity > 0)
                {
                    inStockProducts.Add(prod);
                }
            }
            return inStockProducts;
        }

        public List<Product> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).ToList();
        }
    }
}
