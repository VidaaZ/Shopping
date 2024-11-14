using OnlineShop.entities;
using OnlineShop.Models.SignUp;

namespace OnlineShop.Services.SignUp_UserInformation
{
    public interface ISignUpService
    {
        Task<bool> SignUpAsync(SignUpRequestDto userInfo);
        Task<bool> LoginAsync(string username, string password);
    }
}
