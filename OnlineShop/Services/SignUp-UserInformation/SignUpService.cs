using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Models.SignUp;
using OnlineShop.Models.User;
using OnlineShop.Repository.SignUp_UserInformation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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






        public async Task<UserLoginResponseDto> LoginAsync(string username, string password)
        {
            var user = await _signUpRepository.GetUSerByUserNameAsync(username);
            


            if (user is null)
                return new UserLoginResponseDto();
       

            var verifyPassword = VerifyPassword(password, user.PasswordHash);

            if (!verifyPassword)

                throw new Exception("Invalid password");

            var token = GenerateJwtToken(user);

            var result = _mapper.Map<entities.User, UserResponseDto>(user);

            return new UserLoginResponseDto
            {
                User = result,
                Token = token
            };


        }
        private string GenerateJwtToken(entities.User user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim("role", user.RoleId.ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5137",
                audience: "http://localhost:5137",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        private bool VerifyPassword(string password, string hashedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

