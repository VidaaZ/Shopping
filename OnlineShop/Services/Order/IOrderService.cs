using OnlineShop.Models.Order;

namespace OnlineShop.Services.Order
{
    public interface IOrderService
        
    {
        Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto dto);
        Task<OrderResponseDto> Order(int productId, int count, OrderDetailsDto orderDetails, bool notifyOnAvailable = false);
    }
}
