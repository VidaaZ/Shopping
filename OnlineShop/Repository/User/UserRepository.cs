using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task CreateUser(Models.User entity)
        {
            await _dbContext.Users.AddAsync(entity);  
            await _dbContext.SaveChangesAsync();      
        }

        
        public async Task UpdateUserAsync(Models.User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();  
        }

        
        public async Task DeleteUserAsync(Models.User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();  
        }

        
        public async Task<Models.User> GetUserAsync(string userName)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return result;
        }

        // Get user by ID
        public async Task<Models.User> GetUserByIdAsync(int id)  
        {
            return await _dbContext.Users.FindAsync(id);  
        }

        
        public async Task DeleteUserAsync(int id)  
        {
            var user = await GetUserByIdAsync(id);  
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();  
            }
        }

        // This should just be the Task signature as per your interface
        Task<Models.User> IUserRepository.UpdateUserAsync(Models.User entity)
        {
            throw new NotImplementedException();
        }
    }
}
