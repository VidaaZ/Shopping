﻿using AutoMapper;
using OnlineShop.Models.User;
using OnlineShop.Entities.User;
using OnlineShop.Repository.User;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.entities;


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

        private OnlineShop.entities.User MapToEntity(UserRequestDto dto)
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
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            await _userRepository.DeleteUserAsync(id);  // Call the repository to delete the user
        }

        public Task<UserResponseDto> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

    }
}