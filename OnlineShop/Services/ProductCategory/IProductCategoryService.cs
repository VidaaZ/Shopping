using OnlineShop.Models.ProductCategory;

namespace OnlineShop.Services.ProductCategory
{
    public interface IProductCategoryService
    {
        Task CreateProductCategoryAsync(ProductCategoryRequestDto dto);
        Task UpdateProductCategoryAsync(ProductCategoryRequestDto dto);
        Task DeleteProductCategoryAsync(int id);
        Task<ProductCategoryResponseDto> GetProductCategoryAsync();

    }
}
