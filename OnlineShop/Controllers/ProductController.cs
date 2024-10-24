using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Product;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            await _productService.GetProductsAsync();
            return (Ok);
        }


    } }
