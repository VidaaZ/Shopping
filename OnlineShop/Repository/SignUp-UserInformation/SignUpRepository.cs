using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Repository.SignUp_UserInformation;

namespace OnlineShop.Repository.UserInformation_SignUp
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SignUpRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<entities.SignUp> AddUserAsync(entities.SignUp user)
        {
            await _dbContext.SignUp.AddAsync(user);
            _dbContext.SaveChanges();
            return user;
        }
        public async Task<entities.SignUp> GetUSerByUserNameAsync(string username)
        {
            var result = await _dbContext.SignUp.FirstOrDefaultAsync(u => u.UserName == username);
            return result;
        }
        public async Task<bool> UserExistsAsync(string username)
        {
            var result = await _dbContext.SignUp.AnyAsync(u => u.UserName == username);
            return result;
        }
    }
}
