using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class ProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashDictionary;
        private Dictionary<string, CatFood> _catFoodDictionary;

        public ProductLogic() 
        {
            _products = new List<Product>();
            _dogLeashDictionary = new Dictionary<string, DogLeash>();
            _catFoodDictionary = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
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

        public DogLeash GetDogLeashByName(string name)
        {
            return _dogLeashDictionary[name];
        }

        public CatFood GetCatFoodByName(string name)
        {
            return _catFoodDictionary[name];
        }

        public bool IsProductInCatFoodDictionary(string name)
        {
            return _catFoodDictionary.ContainsKey(name);
        }
    }
}
