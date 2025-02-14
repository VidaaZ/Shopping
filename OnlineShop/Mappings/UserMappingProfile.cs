using AutoMapper;
using OnlineShop.Models.User;
using OnlineShop.entities;
using Microsoft.Identity.Client;
namespace OnlineShop.Mappings
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestDto,User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            this.CreateMap<entities.User, UserResponseDto>();

            
        }
    }
}
