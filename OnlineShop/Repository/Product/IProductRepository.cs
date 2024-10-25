namespace OnlineShop.Repository.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<entities.Product>> GetProductsAsync();
        void DeleteProduct(entities.Product product);
        Task<entities.Product> GetProductById(int id);
        Task<entities.Product> CreateProductAsync(entities.Product product);
        Task<entities.Product> UpdateProductRepository(entities.Product product);
    }
    
}
