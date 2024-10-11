using OnlineShop.Models2.User;

namespace OnlineShop.Services.User
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDto dto);
        Task<UserResponseDto> GetUsersAsync();
        Task UpdateUserAsync(UserRequestDto dto);
        Task DeleteUserAsync(int id);

    }
}
