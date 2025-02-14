using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Exceptions;
using OnlineShop.Models.Product;
using OnlineShop.Models.User;
using OnlineShop.Repository.Product;
using System.IdentityModel.Tokens.Jwt;

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

        //public async Task<ProductRequestDto> CreateProductAsync(ProductRequestDto dto, string token)
        //{
        //    try { 
        //    //{
        //    //    if (user.RoleId != 3)
        //    //        throw new AccessDeniedException();
        //    // Parse and validate the token
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtToken = handler.ReadJwtToken(token);

        //    // Extract the "role" claim
        //    var roleIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

        //            //if (roleIdClaim == null || roleIdClaim != "3") // Allow only RoleId == 3 (Seller)
        //            //{
        //            //    throw new AccessDeniedException("You are not authorized to add products.");
        //            //}
        //            var product = _mapper.Map<entities.Product>(dto);

        //        var createdProduct = await _productRepository.CreateProductAsync(product);
        //        return _mapper.Map<ProductRequestDto>(createdProduct);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException("An error occurred while creating the product.", ex);
        //    }
        //}
        public async Task<ProductRequestDto> CreateProductAsync(ProductRequestDto dto, string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    throw new UnauthorizedAccessException("Token is required.");
                }

                // Parse and validate the token
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    throw new UnauthorizedAccessException("Invalid token.");
                }

                // Extract "role" claim from the token
                var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role");

                if (roleClaim == null)
                {
                    throw new UnauthorizedAccessException("Role information is missing in the token.");
                }

                int roleId = int.Parse(roleClaim.Value);

                // 🔹 Check RoleId to allow only RoleId = 3 (Seller)
                if (roleId != 3)
                {
                    throw new UnauthorizedAccessException("You are not authorized to add products.");
                }

                // Proceed with product insertion
                var product = _mapper.Map<entities.Product>(dto);
                var createdProduct = await _productRepository.CreateProductAsync(product);

                return _mapper.Map<ProductRequestDto>(createdProduct);
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


    }
}
