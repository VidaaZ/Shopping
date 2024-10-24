using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.User;
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
          var users=  await _userService.GetUsersAsync();
            return Ok(users);
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
        public async Task<IActionResult> UpdateUserAsync(UserUpdateRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
        public async Task<IActionResult> DeleteUserAsync(Guid id)
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

        [HttpDelete]
        [Route("user-id/{id}/status")]
        public async Task<IActionResult> StatsuUserAsync(Guid id)
        {
            try
            {
                await _userService.StatusUserAsync(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
