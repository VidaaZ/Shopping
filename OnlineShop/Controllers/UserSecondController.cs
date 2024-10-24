using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.User;

namespace OnlineShop.Controllers
{
    public class UserSecondController : Controller
    {
        private readonly IUserService _userService;

        public UserSecondController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetActiveUsersByRole/{roleId}")]
        public async Task<IActionResult> GetActiveUsersByRole(int roleId)
        {
            var users = await _userService.GetActiveUsersByRoleAsync(roleId);

            if (users == null || !users.Any())
            {
                return NotFound("No active users found for the specified role.");
            }

            return Ok(users);
        }
    }
}

