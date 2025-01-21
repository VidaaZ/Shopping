using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Models.Product;
using OnlineShop.Models.User;
using OnlineShop.Services.Product;
using OnlineShop.Services.User;
using System.Security.Claims;


namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        #region properties
        private IUserService _userService;
        private IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        #endregion

        #region Constructor

        public ProductController(IProductService productService, ILogger<ProductController> logger,IUserService userService)
        {
            _productService = productService;
            _logger = logger;
            _userService = userService;
        }

       

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            _logger.LogInformation("Fetching all products");
            try
            {
                var results = await _productService.GetProductsAsync();
             
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
        [Route("insert-product")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductRequestDto dto)
        {
            try
            {
                
                var result = await _productService.CreateProductAsync(dto, dto.User);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new product.");
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
        [HttpGet("search")]
        public async Task<IActionResult> SearchProductsAsync([FromQuery] string? productName, [FromQuery] string? categoryName)
        {
            _logger.LogInformation("Searching products by productname and categoryname");
            try
            {
                var results = await _productService.SearchProductsAsync(productName, categoryName);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching products");
                return BadRequest(ex.Message);
            }
        }
   

        #endregion
    }
}
