using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.Order;
using OnlineShop.Services.Order;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        [Route("product-id/{productId}/count/{count}")]
        public async Task<IActionResult> Order(int productId, int count)
        {
            var result = await _orderService.Order(productId, count);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderRequestDto dto)
        {
            
            try
            {
                var result = await _orderService.CreateOrderAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating order");
                return BadRequest(ex.Message);
            }
        }
    }
}
   
