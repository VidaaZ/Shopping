using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.ProductCategory;
using OnlineShop.Models.User;
using OnlineShop.Services.ProductCategory;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/product-category")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
          var categories=  await _productCategoryService.GetProductCategoryAsync();
            return Ok(categories);
        }
        [HttpPost]
        [Route("generate-product-category")]
        public async Task<IActionResult> CreateAsync(ProductCategoryRequestDto dto)
        {
            await _productCategoryService.CreateProductCategoryAsync(dto);

            //todo:
            //var role = _db.Roles.Find(dto.RoleId);


            return Ok();
        }
        [HttpPut]
        [Route("update-product-category")]
        public async Task<IActionResult> UpdateProductCategoryAsync(ProductCategoryRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productCategoryService.UpdateProductCategoryAsync(dto);

                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("user-id/{id}")]
        public async Task<IActionResult> DeleteProductCategoryAsync(int id)
        {
            try
            {
                await _productCategoryService.DeleteProductCategoryAsync(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

