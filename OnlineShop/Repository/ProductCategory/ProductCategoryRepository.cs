using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Repository.ProductCategory
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateProductCategory(entities.ProductCategory entity)
        {
            await _dbContext.ProductCategories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<entities.ProductCategory> UpdateProductCategoryAsync(entities.ProductCategory entity)
        {
            _dbContext.ProductCategories.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteProductCategoryAsync(entities.ProductCategory productCategory)
        {
            _dbContext.ProductCategories.Remove(productCategory);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<entities.ProductCategory> GetProductCategoryAsync(string name)
        {
            var result = await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }

        public async Task<entities.ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _dbContext.ProductCategories.FindAsync(id);
        }

        public Task<entities.ProductCategory> GetProdyctCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<entities.ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _dbContext.ProductCategories.ToListAsync();
        }
    }
}
