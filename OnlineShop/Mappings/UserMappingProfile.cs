using AutoMapper;
using OnlineShop.Models.User;
using OnlineShop.entities;
namespace OnlineShop.Mappings
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestDto,User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserResponseDto>();
        }
    }
}
