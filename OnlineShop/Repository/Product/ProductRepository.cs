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
        public async Task<List<entities.Product>> GetAllProductsAsync(){
            return await _dbContext.Products.ToListAsync();
        }
    }
}
