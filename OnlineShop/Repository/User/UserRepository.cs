using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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


        public async Task CreateUser(entities.User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<entities.User> UpdateUserAsync(entities.User entity)
        {

            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task DeleteUserAsync(entities.User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<entities.User> GetUserAsync(string userName)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return result;
        }


        public async Task<entities.User> GetUserByIdAsync(int id)
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



    }
}
