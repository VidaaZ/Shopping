using OnlineShop.Models.User;

namespace OnlineShop.Services.Product
{
    public class IProductService
    {
        Task<UserResponseDto> GetProductsAsync();
    }
}
