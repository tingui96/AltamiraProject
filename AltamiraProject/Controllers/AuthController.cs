using AltamiraProject.ApiResponse;
using Contracts.Services;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AltamiraProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            await _serviceManager.AuthService.RegisterAsync(register);
            return Ok(new ApiOkResponse());
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var result = await _serviceManager.AuthService.LoginAsync(login);
            return Ok(new ApiOkResponse(result));
        }
    }
}
