﻿using OnlineShop.Models.User;

namespace OnlineShop.Services.User
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDto dto);
        Task<UserResponseDto> GetUsersAsync();
        Task UpdateUserAsync(UserUpdateRequestDto dto);
        Task DeleteUserAsync(Guid id);
        Task StatusUserAsync(Guid id);
        
    }
}
