using OnlineShop.Models.Product;
using OnlineShop.Models.User;
using OnlineShop.Repository.Product;
using OnlineShop.Repository.User;

namespace OnlineShop.Services.Product
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;


        }
        public async Task<List<ProductRequestDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            var result = products.Select(product => new ProductRequestDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity
           }).ToList();
            return result;
            
        }

        Task<List<UserRequestDto>> IProductService.GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
