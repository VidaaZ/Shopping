using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Product;

namespace OnlineShop.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
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
         var products=await _productService.GetProductsAsync();
            return Ok (products);
        }


    } }
