using OnlineShop.Models.Product;
using OnlineShop.Models.User;
namespace OnlineShop.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        void DeleteProduct(int id);
        Task<ProductRequestDto> CreateProductAsync(ProductRequestDto dto, UserResponseDto user);
        Task<bool> HasProductAsync(int id);
        Task<ProductResponseDto> UpdateProductAsync(UpdateProductRequestDto dto);
        Task<IEnumerable<ProductResponseDto>> SearchProductsAsync(string productName, string categoryName);
    }
}
