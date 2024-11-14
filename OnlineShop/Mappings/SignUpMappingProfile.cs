using AutoMapper;
using OnlineShop.entities;
using OnlineShop.entities; 
using OnlineShop.Models.SignUp; 

namespace OnlineShop.Mappings
{
    public class SignUpMappingProfile : Profile
    {
        public SignUpMappingProfile()
        {
            
            CreateMap<SignUp, SignUpResponseDto>();
            CreateMap<SignUpRequestDto, SignUp>();
        }
    }
}