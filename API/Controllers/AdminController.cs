using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly UserManager<User> userManager;

        public AdminController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Policy = "requireAdminRole")]
        [HttpGet("users")]
        public async Task<ActionResult> GetUsersWithRole()
        {
            var users = await userManager.Users.OrderBy(u => u.UserName).Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Roles = u.UserRoles.Select(u => u.Role.Name).ToList()
            }).ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "requireAdminRole")]
        [HttpGet("edit/{username}")]
        public async Task<ActionResult> EditUserRoles(string username, [FromQuery]string roles)
        {
            if(string.IsNullOrEmpty(roles))
                return BadRequest("");

            var selectedRoles = roles.Split(",").ToArray();

            var user = await userManager.FindByNameAsync(username);

            if(user == null) 
                return NotFound("Không tìm thấy tài khoản!");

            var userRoles = await userManager.GetRolesAsync(user);

            var result = await userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
                return BadRequest("Thêm Quyền thất bại!");

            result = await userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded)
                return BadRequest("Thêm Quyền thất bại!");

            return Ok(await userManager.GetRolesAsync(user));
        }

    }
}
