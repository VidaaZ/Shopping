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

        public async Task<entities.User> GetUserAsync(string userName)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return result;
        }


        public async Task<entities.User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }


        public async Task DeleteUserAsync(entities.User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StatusUser(entities.User user)
        {
            user.IsActive = false;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<entities.User>> GetActiveUsersByRoleAsync(int roleId)
        {
            return await _dbContext.Users
                .Include(u => u.Role) 
                .Where(u => u.RoleId == roleId && u.IsActive) 
                .ToListAsync();
        }
        public async Task<List<entities.User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
