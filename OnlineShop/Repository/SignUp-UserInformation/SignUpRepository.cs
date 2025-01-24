using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data;
using OnlineShop.entities;
using OnlineShop.Repository.SignUp_UserInformation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.Repository.UserInformation_SignUp
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SignUpRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<entities.User> AddUserAsync(entities.User user) //todo: Change It to User Entitiy
        {
            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();
            return user;
        }
        public async Task<entities.User> GetUSerByUserNameAsync(string username)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
            
            return result;
        }
     
        public async Task<entities.User> UserExistsAsync(string username,string email) //todo:username and email shoud be both input
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username || u.Email == email);
            return result;
        }
    }
}
