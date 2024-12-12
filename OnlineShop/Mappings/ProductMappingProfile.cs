using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.Product;

namespace OnlineShop.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Define your mappings here
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductRequestDto, Product>();
            CreateMap<UpdateProductRequestDto, Product>();
        }
    }
}
