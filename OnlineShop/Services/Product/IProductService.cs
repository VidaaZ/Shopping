using OnlineShop.Models.User;

namespace OnlineShop.Services.Product
{
    public interface IProductService
    {
        Task<List<UserRequestDto>> GetProductsAsync();
    }
}
