namespace OnlineShop.Repository.User
{
    public interface IUserRepository 
    {
        Task CreateUser(entities.User entity);
        Task<entities.User> GetUserAsync(string userName);
        Task<entities.User> GetUserByIdAsync(Guid id);
        Task<entities.User> UpdateUserAsync(entities.User entity);
        Task DeleteUserAsync(entities.User user);
        Task StatusUser(entities.User user);
        Task<List<entities.User>> GetAllUsersAsync();
        Task<List<entities.User>> GetActiveUsersByRoleAsync(int roleId);
    }
}
