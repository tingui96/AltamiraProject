using Contracts.Services;
using Entities.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace AltamiraProject.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager repositoryService)
        {
            _serviceManager = repositoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _serviceManager.UserService.GetAllUserAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _serviceManager.UserService.GetUserByIdAsync(id);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserToUpdateDTO user)
        {
            var result = await _serviceManager.UserService.UpdateUserAsync(id, user);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _serviceManager.UserService.DeleteUserAsync(id);
            return Ok(result);
        }
        [HttpPost("{id}/addrole")]
        public async Task<IActionResult> AddRoleToUser(Guid id,Guid roleId)
        {
            var result = await _serviceManager.UserService.AddRoleToUser(roleId, id);
            return Ok(result);
        }
    }
}
