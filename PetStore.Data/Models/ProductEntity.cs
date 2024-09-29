
namespace PetStore.Data;

public class ProductEntity : IProductRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

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