
using OnlineShop.Models.Order;
using OnlineShop.Models.Product;
using OnlineShop.Repository.Order;
using OnlineShop.Repository.ProductCategory;
using OnlineShop.Services.Email;
using OnlineShop.Services.Product;

namespace OnlineShop.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public OrderService(IProductService productService, IOrderRepository orderRepository, IEmailService emailService)
        {
            _productService = productService;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }
        public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto dto)
        {
            try
            {
                var mapToEntity = MapToEntity(dto);
                var createOrder = await _orderRepository.CreateOrderAsync(mapToEntity);
                var mapToDto = MapToDto(createOrder);
                return mapToDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the product.", ex);
            }
        }
        private entities.Order MapToEntity(OrderRequestDto dto)
        {
            entities.Order order = new entities.Order();

            order.CategoryId = dto.CategoryId;
            order.Name = dto.Name;
            order.Family = dto.Family;
            order.UserId = dto.UserId;
            order.ProductId = dto.ProductId;
            order.Address = dto.Address;
            order.PhoneNumber = dto.PhoneNumber;
            order.PostalCode = dto.PostalCode;


            return order;
        }
        private OrderResponseDto MapToDto(entities.Order order)
        {
            OrderResponseDto dto = new OrderResponseDto();

            dto.Name = order.Name;
            dto.Family = order.Family;
            dto.UserId = order.UserId;
            dto.ProductId = order.ProductId;
            dto.Address = order.Address;
            dto.PhoneNumber = order.PhoneNumber;
            dto.PostalCode = order.PostalCode;

            return dto;
        }

        public async Task <OrderResponseDto> Order(int productId, int count, OrderDetailsDto orderDetails, bool notifyOnAvailable = false)
        {
            var productCount = await _productService.GetProductCountAsync(productId);
            if (count > productCount)
            {

                if (notifyOnAvailable)
                {
                   
                    await _emailService.SendProductAvailabilityNotificationAsync(orderDetails.Email, "Product Name"); 
                    throw new Exception("Mojod nist. Notification baraye mojod shodan ersal mishavad.");
                }
                else
                {
                    throw new Exception("Mojod nist");
                }
            }
        
                await _productService.UpdateProductCountAsync(productId, count);
                var orderRequestDto = new OrderRequestDto
                {
                    ProductId = productId,
                    UserId = orderDetails.UserId,
                    Address = orderDetails.Address,
                    PhoneNumber = orderDetails.PhoneNumber,
                    PostalCode = orderDetails.PostalCode,
                    Email = orderDetails.Email,
                    Name = orderDetails.Name,
                    Family = orderDetails.Family


                };
                var result = await CreateOrderAsync(orderRequestDto);
                

                return result;

            }

        
    }

      
    }

         
