using Microsoft.AspNetCore.Mvc;
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

        #endregion

        #region Constructor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var results = await _productService.GetProductsAsync();
                return Ok(results);

            }
            catch (Exception ex)
            {
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductRequestDto dto)
        {
            var result = await _productService.CreateProductAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductRequestDto dto)
        {
            try
            {
                var result = await _productService.UpdateProductAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
