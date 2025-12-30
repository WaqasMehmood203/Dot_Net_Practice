using EMS.API.Entities.DB2_Entities;
using EMS.API.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        public readonly IUserService _userService;
        public UserController(IUserService userService, IConfiguration config)
        {
            _config = config;
            _userService = userService;
        }

        [HttpGet("Environment")]
        public IActionResult Environment()
        {
            return Ok(_config["Environment"]);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _userService.AddUserAsync(user);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("Id Not Found");
            }
            var result = await _userService.UpdateUserAsync(id, user);
            if (result == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var user = await _userService.DeleteUserAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpGet("getUserlist")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userService.GetAllUserAsync());
        }
        
    }

}

