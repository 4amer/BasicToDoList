using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAuthService _userService;
        public UserController(ILogger<UserController> logger, IAuthService userService) 
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("reg")]
        public async Task<IActionResult> RegistrateUser([FromBody] Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _userService.RegistraterAsync(user);

                return Ok();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Can not authorisate user");
                return StatusCode(500, "Can not authorisate user");
            }
        }

        [HttpPost("log")]
        public async Task<IActionResult> LogginUser([FromBody] Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _userService.RegistraterAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Can not authorisate user");
                return StatusCode(500, "Can not authorisate user");
            }
        }
    }
}
