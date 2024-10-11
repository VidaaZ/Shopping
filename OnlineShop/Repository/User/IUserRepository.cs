using OnlineShop.Models;

namespace OnlineShop.Repository.User
{
    public interface IUserRepository 
    {
        Task CreateUser(Models.User entity);
        Task<Models.User> GetUserAsync(string userName);
        Task<Models.User> GetUserByIdAsync(int id);
        Task<Models.User> UpdateUserAsync(Models.User entity);
        Task DeleteUserAsync(int id);
    }
}
