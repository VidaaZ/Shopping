using AutoMapper;
using OnlineShop.Models2.User;
using OnlineShop.Repository.User;


namespace OnlineShop.Services.User
{
    public class UserService : IUserService
    {
        #region properties

        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository/*, IMapper mapper*/)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
        }

        #endregion

        #region Methods
        //public async Task<List<User>> GetUsersAsync()
        //{
        //    // Delegate the actual database logic to the repository
        //    return await _userRepository.GetUsersAsync();
        //}

        public async Task CreateUserAsync(UserRequestDto dto)
        {
            bool isAvailable = await IsUserAvailable(dto.UserName);
            if (!isAvailable)
            {
                //var entity = _mapper.Map<User>(dto);
                var entity = MapToEntity(dto);
                await _userRepository.CreateUser(entity);
            }
            else
                throw new Exception("douplicate");
        }
        public async Task UpdateUserAsync(UserRequestDto dto)
        {
            var user = await _userRepository.GetUserAsync(dto.UserName); 
            if (user is null)
            {
                throw new Exception("User not found.");
            }
            user.Name = dto.Name;
            user.Family = dto.Family;
            user.Email = dto.Email;
            user.Password = dto.Password;
            // Ensure Password matches ConfirmPassword before updating
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Passwords do not match.");
            }

            // Optionally hash the password before storing it
            //var passwordHasher = new PasswordHasher<User>();
            //user.Password = passwordHasher.HashPassword(user, dto.Password);

            //_mapper.Map(dto, user);

            await _userRepository.UpdateUserAsync(user);
    }

    //todo
    private async Task<bool> IsUserAvailable(string userName)
        {
            return false;
        }

        private Models.User MapToEntity(UserRequestDto dto)
        {
            var entity = new Models.User();

            entity.UserName = dto.UserName;
            entity.RoleId = dto.RoleId;
            entity.Email = dto.Email;
            entity.ConfirmPassword = dto.ConfirmPassword;
            entity.Password = dto.Password;
            entity.Name = dto.Name;
            entity.Family = dto.Family;

            return entity;
        }
    public async Task DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);  // Check if the user exists
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        await _userRepository.DeleteUserAsync(id);  // Call the repository to delete the user
    }

        Task<UserResponseDto> IUserService.GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}