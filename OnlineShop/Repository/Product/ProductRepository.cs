using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<entities.Product> CreateProductAsync(entities.Product product)
        {
            await _dbContext.Products.AddAsync(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(entities.Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public Task<entities.Product> GetProductById(int id)
        {
            var result = _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            return result;
        }

        public async Task<IEnumerable<entities.Product>> GetProductsAsync()
        {
            var results = await _dbContext.Products.ToListAsync();
            return results;
        }

        public async Task<entities.Product> UpdateProductRepository(entities.Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

           
            _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);

            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }

    }
}
