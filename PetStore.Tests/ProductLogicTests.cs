using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using Moq;
using PetStore.ConsoleApp.Logic;
using PetStore.Data;

namespace PetStore.Tests;

[TestClass]
public class ProductLogicTests
{
    private Mock<IProductRepository> _mockProductRepository { get; set; }        
    private Mock<IOrderRepository> _mockOrderRepository { get; set; }
    private ProductLogic _productLogic {get; set; }
    private OrderLogic _orderLogic {get; set; }

    public ProductLogicTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockOrderRepository = new Mock<IOrderRepository>();
        _productLogic = new ProductLogic(_mockProductRepository.Object);
        _orderLogic = new OrderLogic(_mockOrderRepository.Object);
    }

    [TestMethod]
    public void GetProductById_CallsRepo()
    {
        // Arrange
        _mockProductRepository.Setup(x => x.GetProductById(10))
	        .Returns(new Product { ProductId = 10, Name = "test product" });

        // Act
        _productLogic.GetProductById(10);
    
        // Assert
        _mockProductRepository.Verify(x => x.GetProductById(10), Times.Once);
    }
}