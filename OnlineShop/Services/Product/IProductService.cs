using OnlineShop.Models.Product;
namespace OnlineShop.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        void DeleteProduct(int id);
        Task<ProductResponseDto> CreateProductAsync(ProductRequestDto dto);
        Task<bool> HasProductAsync(int id);
        Task<ProductResponseDto> UpdateProductAsync(UpdateProductRequestDto dto);
    }
}
