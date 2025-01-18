using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.Product;
using OnlineShop.Services.Product;
using System.Drawing.Text;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/receipt")]
    public class ReceiptController:ControllerBase
    {
        private readonly IProductService _productService;

        public ReceiptController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ActionName("SumProduct")]
        [Route("sum-product")]
        public async Task<IActionResult> SumProduct(ProductIdsRequestDto dto)
        {
            var productPrices = await _productService.GetPriceAsync(dto.ProductIds);
            var totalSum = productPrices.Sum(p => p.Price);
            return Ok(new { TotalSum = totalSum });


           
        }
    }
    
}
