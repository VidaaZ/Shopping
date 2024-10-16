using OnlineShop.Models.User;
using OnlineShop.Entities.User;

namespace OnlineShop.Services.User
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDto dto);
        Task<UserResponseDto> GetUsersAsync();
        Task UpdateUserAsync(UserUpdateRequestDto dto);
        Task DeleteUserAsync(int id);

    }
}
