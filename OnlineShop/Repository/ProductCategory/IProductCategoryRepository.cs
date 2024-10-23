namespace OnlineShop.Repository.ProductCategory
{
    public interface IProductCategoryRepository
    {
        Task CreateProductCategory(entities.ProductCategory entity);
        Task<entities.ProductCategory> UpdateProductCategoryAsync(entities.ProductCategory entity);
        Task DeleteProductCategoryAsync(entities.ProductCategory productCategory);
      
        Task<entities.ProductCategory> GetProductCategoryAsync(string name);
        Task<entities.ProductCategory> GetProductCategoryByIdAsync(int id);
        Task DeleteProductCategoryAsync(int id);
        Task<List<entities.ProductCategory>> GetAllProductCategoriesAsync();
    }
}
