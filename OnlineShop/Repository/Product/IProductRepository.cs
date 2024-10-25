namespace OnlineShop.Repository.Product
{
    public interface IProductRepository
    {
        Task<List<entities.Product>> GetAllProductsAsync();
    }
    
}
