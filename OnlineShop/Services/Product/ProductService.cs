using OnlineShop.entities;
using OnlineShop.Models.Product;
using OnlineShop.Repository.Product;

namespace OnlineShop.Services.Product
{
    public class ProductService : IProductService
    {
        #region properties

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        #endregion

        #region Methods

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            try
            {
                var results = await _productRepository.GetProductsAsync();
                if (results.Any())
                {
                    var maptoDto = MapToDto(results);
                    return maptoDto;
                }
                var dto = new List<ProductResponseDto>();
                return dto;
            }
            catch{
                throw new InvalidOperationException("An error occurred while fetching the products.");
            }
        }

        private IEnumerable<ProductResponseDto> MapToDto(IEnumerable<entities.Product> products)
        {
            var result = products.Select(product => new ProductResponseDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            }).ToList();
            return result;
        }
        public void DeleteProduct(int id)
        {
            try
            {

                var product = _productRepository.GetProductById(id).Result;

                if (product is null)
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
                var mapToEntity = MapToEntity(dto);
                var createProduct = await _productRepository.CreateProductAsync(mapToEntity);
                var mapToDto = MapToDto(createProduct);
                return mapToDto;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the product.", ex);
            }
            }
    
        private ProductResponseDto MapToDto(entities.Product product)
        {
            ProductResponseDto dto = new ProductResponseDto();

            dto.UpdatedDate = product.UpdatedDate;
            dto.CreatedDate = product.CreatedDate;
            dto.Price = product.Price;
            dto.CategoryId = product.CategoryId;
            dto.Description = product.Description;
            dto.Name = product.Name;

            return dto;
        }

        private entities.Product MapToEntity(ProductRequestDto dto)
        {
            entities.Product product = new entities.Product();

            product.CategoryId = dto.CategoryId;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.CreatedDate = DateTime.Parse(dto.CreatedDate);
            product.UpdatedDate = DateTime.Parse(dto.UpdatedDate);
            product.StockQuantity = (int) dto.StockQuantity;

            return product;
        }

        public async Task<bool> HasProductAsync(int id)
        {
            try
            {
                var result = await _productRepository.GetProductById(id);

                if (result is null)
                    throw new KeyNotFoundException("Product with the specified ID not found.");

                return true;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("An error occurred while checking product existence.", ex);
            }
        }

        public entities.Product MapToEntity(UpdateProductRequestDto dto)
        {
            entities.Product entity = new entities.Product();

            entity.ProductId = dto.Id;
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
            entity.StockQuantity = (int) dto.StockQuantity;
            entity.UpdatedDate = DateTime.Parse(dto.UpdatedDate);
            entity.CreatedDate = DateTime.Parse(dto.CreatedDate);
            entity.CategoryId = dto.CategoryId;

            return entity;

        }

        public async Task<ProductResponseDto> UpdateProductAsync(UpdateProductRequestDto dto)
        {
            try
            {
                var getProduct = await _productRepository.GetProductById(dto.Id);
            if (getProduct is null)
                throw new KeyNotFoundException("Product with the specified ID not found.");
            
                var mapToEntity = MapToEntity(dto);
                var updateProduct = await _productRepository.UpdateProductRepository(mapToEntity);
                var mapToDto = MapToDto(updateProduct);
                return mapToDto;
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
        }

        #endregion
    }
}
