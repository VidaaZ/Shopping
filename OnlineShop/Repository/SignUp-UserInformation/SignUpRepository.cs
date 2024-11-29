using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.entities;
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
        public async Task<entities.SignUp> AddUserAsync(entities.SignUp user) //todo: Change It to User Entitiy
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
        public async Task<SignUp> UserExistsAsync(string username,string email) //todo:username and email shoud be both input
        {
            var result = await _dbContext.SignUp.FirstOrDefaultAsync(u => u.UserName == username || u.Email == email);
            return result;
        }
    }
}
