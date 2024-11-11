using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using OnlineShop.Models.Product;
using OnlineShop.Services.Product;


namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        #region properties

        private IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        #endregion

        #region Constructor

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            //_logger.LogInformation("Fetching all products");
            try
            {
                var results = await _productService.GetProductsAsync();
                //_logger.LogInformation("Successfully fetched {Id} products", results.Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching products");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("product-id/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            _logger.LogInformation("Attempting to delete product with ID {Id}", id);
            try
            {
                _productService.DeleteProduct(id);
                _logger.LogInformation("Product with ID {Id} deleted successfully", id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting product with ID {Id}", id);
                return BadRequest("An error occurred while deleting the product.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductRequestDto dto)
        {
            _logger.LogInformation("Creating a new product");
            try
            {
                var result = await _productService.CreateProductAsync(dto);
                _logger.LogInformation("Product created successfully with Name {Name}", result.Name);
                return Ok(result);
            }
            
                catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new product");
                return BadRequest("An error occurred while creating the product.");
            }
        
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductRequestDto dto)
        {
            _logger.LogInformation("Updating product with ID {Id}", dto.Id);
            try
            {
                var result = await _productService.UpdateProductAsync(dto);
                _logger.LogInformation("Product with ID {Id} updated successfully", dto.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating product with ID {Id}", dto.Id);
                return BadRequest("An error occurred while updating the product.");
            }
        }

        #endregion
    }
}
