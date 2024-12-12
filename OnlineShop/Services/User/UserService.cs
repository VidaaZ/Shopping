using AutoMapper;
using OnlineShop.entities;
using OnlineShop.Models.User;
using OnlineShop.Repository.User;

namespace OnlineShop.Services.User
{
    public class UserService : IUserService
    {
        #region properties

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        //public async Task<List<User>> GetUsersAsync(){
        // Delegate the actual database logic to the repository
        //   return await _userRepository.GetUsersAsync();
        // }

        public async Task CreateUserAsync(UserRequestDto dto)
        {
            bool isAvailable = await IsUserAvailable(dto.UserName);
            if (!isAvailable)
            {
                var hashedPassword = HashPassword(dto.Password);
                var entity = _mapper.Map<entities.User>(dto);
                entity.PasswordHash = hashedPassword;
                await _userRepository.CreateUser(entity);
            }
            else
                throw new Exception("douplicate");
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        public async Task UpdateUserAsync(UserUpdateRequestDto dto)
        {


            var user = await _userRepository.GetUserAsync(dto.UserName);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user = _mapper.Map<entities.User>(dto);
            await _userRepository.UpdateUserAsync(user);






            //if (dto.Password != dto.ConfirmPassword)
            //{
            //    throw new Exception("Passwords do not match.");
            //}

            // Optionally hash the password before storing it
            // var passwordHasher = new PasswordHasher<User>();
            // user.Password = passwordHasher.HashPassword(user, dto.Password);



            #endregion

        }

        //todo
        private async Task<bool> IsUserAvailable(string userName)
        {
            return false;
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetUserById(id);

            await _userRepository.DeleteUserAsync(user);
        }

        private async Task<entities.User> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }

        public Task<UserResponseDto> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StatusUserAsync(Guid id)
        {
            var user = await GetUserById(id);
            _userRepository.StatusUser(user);
        }
    }
}