using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Order;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService productShopping, ILogger<OrderController> logger)
        {
            _productShopping = productShopping;
            _logger = logger;
        }

        [HttpGet]
        [Route("product-id/{productId}/count/{count}")]
        public async Task<IActionResult> Order(int productId, int count)
        {
            var result = await _orderService.Order(productId, count);
            return Ok(result);
        }
    }
}
   
