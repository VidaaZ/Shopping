using AutoMapper;
using OnlineShop.Models2.User;

namespace OnlineShop.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example of mapping UserRequestDto to User model
            CreateMap<UserRequestDto, Models.User>();  // Corrected by adding parentheses
        }
    }
}
