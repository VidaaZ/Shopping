using AutoMapper;
using OnlineShop.Models.SignUp;
using OnlineShop.Models.User;
using OnlineShop.Repository.SignUp_UserInformation;


namespace OnlineShop.Services.SignUp_UserInformation
{
    public class SignUpService : ISignUpService
    {
        private readonly ISignUpRepository _signUpRepository;
        private readonly IMapper _mapper;

        public SignUpService(ISignUpRepository signUpRepository, IMapper mapper)
        {
            _signUpRepository = signUpRepository;
            _mapper = mapper;
        }
        public async Task<bool> SignUpAsync(SignUpRequestDto userInfo)
        {


            var existingUser = await _signUpRepository.UserExistsAsync(userInfo.UserName, userInfo.Email);
            if (existingUser != null)
                throw new Exception("User with the same username or email already exists");

            // Hash the password
            var hashedPassword = HashPassword(userInfo.Password);
            // Map DTO to User entity
            var user = _mapper.Map<entities.User>(userInfo);
            user.PasswordHash = hashedPassword;

            user.IsActive = true; // Default to active
            user.RoleId = 1;      // Assign a default role or get it from the input
            await _signUpRepository.AddUserAsync(user);

            return true;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }






        public async Task<UserResponseDto> LoginAsync(string username, string password)
        {
            var user = await _signUpRepository.GetUSerByUserNameAsync(username);

            if (user is null)
                return new UserResponseDto();

            var verifyPassword = VerifyPassword(password, user.PasswordHash);

            if (!verifyPassword)

                throw new Exception("Invalid password");
            var result = _mapper.Map<entities.User, UserResponseDto>(user);

            return result;



        }



        private bool VerifyPassword(string password, string hashedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

