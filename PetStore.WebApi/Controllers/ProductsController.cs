using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data;
using PetStore.WebApi.Logic;

namespace PetStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;
        public ProductsController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productLogic.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            return await _productLogic.GetProductByIdAsync(productId);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productLogic.AddProductAsync(product);
            return CreatedAtAction(nameof(AddProduct), new { productId = product.ProductId }, product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productLogic.DeleteProductAsync(productId);
            return Ok();
        }
    }
}