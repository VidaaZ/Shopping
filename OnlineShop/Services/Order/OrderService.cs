
using OnlineShop.Repository.ProductCategory;
using OnlineShop.Services.Product;

namespace OnlineShop.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;

        public OrderService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Order(int productId, int count)
        {
            var productCount = await _productService.GetProductCountAsync(productId);
            if (count > productCount)
                throw new Exception("Mojod nist");
            else
                //baed ink karaye kharid anjam shod tedade on product update mikoni
                //await _productService.UpdateProductCountAsync(productId,count);


        }
    }
}
