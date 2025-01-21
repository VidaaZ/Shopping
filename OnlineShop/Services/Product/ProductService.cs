using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.Product;
using OnlineShop.Repository.Product;

namespace OnlineShop.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetProductsAsync();
                return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
            }
            catch
            {
                throw new InvalidOperationException("An error occurred while fetching the products.");
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id).Result;

                if (product == null)
                    throw new KeyNotFoundException("Product with the specified ID not found.");

                _productRepository.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the product.", ex);
            }
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto dto)
        {
            try
            {
                var product = _mapper.Map<entities.Product>(dto);
                var createdProduct = await _productRepository.CreateProductAsync(product);
                return _mapper.Map<ProductResponseDto>(createdProduct);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the product.", ex);
            }
        }

        public async Task<bool> HasProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                return product != null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while checking product existence.", ex);
            }
        }

        public async Task<ProductResponseDto> UpdateProductAsync(UpdateProductRequestDto dto)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductById(dto.Id);
                if (existingProduct == null)
                    throw new KeyNotFoundException("Product with the specified ID not found.");

                _mapper.Map(dto, existingProduct);
                var updatedProduct = await _productRepository.UpdateProductRepository(existingProduct);
                return _mapper.Map<ProductResponseDto>(updatedProduct);
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while updating the product.", ex);
            }
        }
        public async Task<IEnumerable<ProductResponseDto>> SearchProductsAsync(string productName, string categoryName)
        {
            var products = await _productRepository.SearchProductsAsync(productName, categoryName);


            var productDto = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

            return productDto;
        }

        public async Task<List<double>> GetPriceAsync(List<int> productIds)
        {
            var prices = await _productRepository.GetAllPricesByIdAsync(productIds);
            return prices.Select(item => item.Price).ToList();
        }
    }
}
