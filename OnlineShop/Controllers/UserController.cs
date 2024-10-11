using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models2.User;
using OnlineShop.Services.User;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            await _userService.GetUsersAsync();
            return Ok();
        }


        [HttpPost]
        [Route("generate-user")]
        public async Task<IActionResult> CreateAsync(UserRequestDto dto)
        {
            await _userService.CreateUserAsync(dto);
    
            //todo:
            //var role = _db.Roles.Find(dto.RoleId);


            return Ok();
        }
        
        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUserAsync(UserRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // This will return validation errors
            }
            try
            {
                await _userService.UpdateUserAsync(dto);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("user-id/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }

}
