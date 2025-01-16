using OnlineShop.entities;
using OnlineShop.Models.SignUp;
using OnlineShop.Models.User;

namespace OnlineShop.Services.SignUp_UserInformation
{
    public interface ISignUpService
    {
        Task<bool> SignUpAsync(SignUpRequestDto userInfo);
        Task<UserResponseDto> LoginAsync(string username, string password);
    }
}
