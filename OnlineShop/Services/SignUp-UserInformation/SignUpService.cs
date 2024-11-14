using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.SignUp;
using OnlineShop.Repository.SignUp_UserInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineShop.Services.SignUp_UserInformation
{
    public class SignUpService
    {
        private readonly ISignUpRepository _signUpRepository;
        private readonly IMapper _mapper;

        public SignUpService(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }
        public async Task<bool>SignUpAsync(SignUpRequestDto userInfo)
        {
            if (await _signUpRepository.UserExistsAsync(userInfo.UserName))
            
                return false;
            
            userInfo.PasswordHash = HashPassword(userInfo.PasswordHash);
            var signup = _mapper.Map<SignUp>(userInfo);
            await _signUpRepository.AddUserAsync(signup);
            return true;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _signUpRepository.GetUSerByUserNameAsync(username);

            if (user == null)
                return false;

            
            return VerifyPassword(password, user.PasswordHash); 
        }

        private string HashPassword(string password)
        {
            
            return password; 
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            
            return password == hashedPassword; 
        }
    }
}

