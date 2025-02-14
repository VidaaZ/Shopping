using OnlineShop.entities;
using OnlineShop.Models.SignUp;
using OnlineShop.Models.User;

namespace OnlineShop.Services.SignUp_UserInformation
{
    public interface ISignUpService
    {
        string GenerateJwtToken(entities.User user);
        Task<bool> SignUpAsync(SignUpRequestDto userInfo);
        Task<UserLoginResponseDto> LoginAsync(string username, string password);
        //Task<UserResponseDto> LoginAsync(string username, string password);
    }
}
