using OnlineShop.Models.Product;
using OnlineShop.Models.User;
using OnlineShop.Repository.Product;
using OnlineShop.Repository.User;

namespace OnlineShop.Services.Product
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;


        }
        //public async Task<UserResponseDto> GetProductsAsync()
        //{
        //    //var products = await _productRepository.GetAllProductsAsync();
        //    //var productDto=products.Select(products=>new ProductResponseDto
        //    //{
        //    //    Name=Product.Name,
                
        //    //}
            
        //    //)
        //}
    }
}
