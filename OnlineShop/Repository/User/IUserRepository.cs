using OnlineShop.entities;

namespace OnlineShop.Repository.User
{
    public interface IUserRepository 
    {
        Task CreateUser(entities.User entity);
        Task<entities.User> GetUserAsync(string userName);
        Task<entities.User> GetUserByIdAsync(int id);
        Task<entities.User> UpdateUserAsync(entities.User entity);
        Task DeleteUserAsync(int id);
    }
}
