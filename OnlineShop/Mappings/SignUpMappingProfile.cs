using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.SignUp; 

namespace OnlineShop.Mappings
{
    public class SignUpMappingProfile : Profile
    {
        public SignUpMappingProfile()
        {
            CreateMap<SignUpRequestDto, User>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))  
                 .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.LastName)) 
                 .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // PasswordHash is handled manually
        }
    }

}