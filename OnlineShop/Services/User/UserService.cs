using OnlineShop.Models.ProductCategory;
using OnlineShop.Models.User;
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
        //public async Task<List<User>> GetUsersAsync(){
        // Delegate the actual database logic to the repository
        //   return await _userRepository.GetUsersAsync();
        // }
        public async Task<List<UserResponseDto>> GetActiveUsersByRoleAsync(int roleId)
        {
            var users = await _userRepository.GetActiveUsersByRoleAsync(roleId);

            if (!users.Any())
                throw new Exception("No user found.");

            return users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Family = user.Family,
                Email = user.Email,
                UserName = user.UserName,
                Role = user.Role.Name,
                IsActive = user.IsActive
            }).ToList();
        }
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

        private OnlineShop.entities.User MapToEntity(UserUpdateRequestDto dto, entities.User entity)
        {

            if (!string.IsNullOrEmpty(dto.Email))
                entity.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Name))
                entity.Name = dto.Name;
            if (!string.IsNullOrWhiteSpace(dto.Family))
                entity.Family = dto.Family;
            if (!string.IsNullOrEmpty(dto.Password))
                if (!string.IsNullOrEmpty(dto.ConfirmPassword) && dto.ConfirmPassword == dto.Password)
                    {
                    entity.Password = dto.Password;
                    entity.ConfirmPassword = dto.ConfirmPassword;
                        
                }

                    return entity;
        }

        public async Task UpdateUserAsync(UserUpdateRequestDto dto)
        {


            var user = await _userRepository.GetUserAsync(dto.UserName);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user = MapToEntity(dto, user);
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

        private entities.User MapToEntity(UserRequestDto dto)
        {
            var entity = new OnlineShop.entities.User();

            entity.UserName = dto.UserName; 
            entity.RoleId = dto.RoleId;
            entity.Email = dto.Email;
            entity.ConfirmPassword = dto.ConfirmPassword;
            entity.Password = dto.Password;
            entity.Name = dto.Name;
            entity.Family = dto.Family;

            return entity;
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var user =await GetUserById(id);

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
        
       

        public async Task StatusUserAsync(Guid id)
        {
            var user = await GetUserById(id);
            _userRepository.StatusUser(user);
        }

      public async Task<List<UserRequestDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var result = users.Select(user => new UserRequestDto
            {
                
                Name = user.Name,
                Family = user.Family,
                Email = user.Email,
                UserName = user.UserName,
                RoleId = user.RoleId,
                
               
            }).ToList();


            return result;

        }
    }
}