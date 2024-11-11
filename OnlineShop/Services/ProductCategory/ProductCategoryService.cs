using Microsoft.EntityFrameworkCore;
using OnlineShop.entities;
using OnlineShop.Models.ProductCategory;
using OnlineShop.Repository.ProductCategory;
using OnlineShop.Repository.User;

namespace OnlineShop.Services.ProductCategory
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task CreateProductCategoryAsync(ProductCategoryRequestDto dto)
        {
            bool isAvailable = await IsProductCategoryAvailable(dto.Name);
            if (!isAvailable)
            {
                var entity = MapToEntity(dto);
                await _productCategoryRepository.CreateProductCategory(entity);
            }
            else
                throw new Exception("douplicate");
        }
        private entities.ProductCategory MapToEntity(ProductCategoryRequestDto dto)
        {
            var entity = new entities.ProductCategory();

            entity.Name = dto.Name;
            entity.CreatedDate = dto.CreateDateTime;


            return entity;
        }
        private async Task<bool> IsProductCategoryAvailable(string name)
        {
            return false;
        }

        public async Task UpdateProductCategoryAsync(ProductCategoryRequestDto dto)
        {


            var productCategory = await _productCategoryRepository.GetProductCategoryAsync(dto.Name);
            if (productCategory == null)
            {
                throw new Exception("User not found.");
            }

            productCategory = MapToEntity(dto);
            await _productCategoryRepository.UpdateProductCategoryAsync(productCategory);

        }
        public async Task DeleteProductCategoryAsync(int id)
        {
            var user = await _productCategoryRepository.GetProductCategoryByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            await _productCategoryRepository.DeleteProductCategoryAsync(id);  
        }

        public async Task<List<ProductCategoryRequestDto>> GetProductCategoryAsync()
        {

            var categories = await _productCategoryRepository.GetAllProductCategoriesAsync();


            var result = categories.Select(category => new ProductCategoryRequestDto
            {
                
                Name = category.Name,
                CreateDateTime = category.CreatedDate
            }).ToList();

            
            return result;
        }

      
    }
}