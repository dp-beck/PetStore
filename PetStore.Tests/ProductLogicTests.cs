using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using Moq;
using PetStore.Data;
using PetStore.WebApi.Logic;

namespace PetStore.Tests;

[TestClass]
public class ProductLogicTests
{
    private Mock<IProductRepository> _mockProductRepository { get; set; }        
    private Mock<IOrderRepository> _mockOrderRepository { get; set; }
    private readonly ProductLogic _productLogic;
    private readonly OrderLogic _orderLogic;  


    public ProductLogicTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockOrderRepository = new Mock<IOrderRepository>();
        _productLogic = new ProductLogic(_mockProductRepository.Object);
    }

    [TestMethod]
    public async Task GetProductById_CallsRepo()
    {
        // Arrange
        _mockProductRepository.Setup(x => x.GetProductByIdAsync(10))
	        .ReturnsAsync(new Product { ProductId = 10, Name = "test product" });

        // Act
        await _productLogic.GetProductByIdAsync(10);
    
        // Assert
        _mockProductRepository.Verify(x => x.GetProductByIdAsync(10), Times.Once);
    }
}