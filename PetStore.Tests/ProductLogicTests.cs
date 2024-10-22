using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using Moq;
using PetStore.Data;

namespace PetStore.Tests;

[TestClass]
public class ProductLogicTests
{
    private Mock<IProductRepository> _mockProductRepository { get; set; }        
    private Mock<IOrderRepository> _mockOrderRepository { get; set; }

    public ProductLogicTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockOrderRepository = new Mock<IOrderRepository>();
    }

    [TestMethod]
    public void GetProductById_CallsRepo()
    {
        // Arrange
        _mockProductRepository.Setup(x => x.GetProductByIdAsync(10))
	        .ReturnsAsync(new Product { ProductId = 10, Name = "test product" });

        // Act
        _mockProductRepository.GetProductById(10);
    
        // Assert
        _mockProductRepository.Verify(x => x.GetProductById(10), Times.Once);
    }
}