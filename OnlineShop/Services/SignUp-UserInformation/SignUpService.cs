using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.SignUp;
using OnlineShop.Repository.SignUp_UserInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineShop.Services.SignUp_UserInformation
{
    public class SignUpService : ISignUpService
    {
        private readonly ISignUpRepository _signUpRepository;
        private readonly IMapper _mapper;

        public SignUpService(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }
        public async Task<bool> SignUpAsync(SignUpRequestDto userInfo)
        {
            var user = await _signUpRepository.UserExistsAsync(userInfo.UserName, userInfo.Email);

            if (user != null)
                throw new Exception("Douplicate!!");
            
            userInfo.PasswordHash = HashPassword(userInfo.PasswordHash);
             
            await _signUpRepository.AddUserAsync(_mapper.Map<SignUpRequestDto, SignUp>(userInfo));
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

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

