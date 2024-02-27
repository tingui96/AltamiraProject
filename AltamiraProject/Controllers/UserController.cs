using AltamiraProject.ApiResponse;
using Contracts.Services;
using Entities.DTO.Request;
using Microsoft.AspNetCore.Authorization;
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
            return Ok(new ApiOkResponse(users));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _serviceManager.UserService.GetUserByIdAsync(id);
            return Ok(new ApiOkResponse(user));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Artist")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserToUpdateDTO user)
        {
            var result = await _serviceManager.UserService.UpdateUserAsync(id, user);
            return Ok(new ApiOkResponse(result));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _serviceManager.UserService.DeleteUserAsync(id);
            return Ok(new ApiOkResponse(result));
        }
        [HttpPost("{id}/addrole")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AddRoleToUser(Guid id,Guid roleId)
        {
            var result = await _serviceManager.UserService.AddRoleToUser(roleId, id);
            return Ok(new ApiOkResponse(result));
        }
    }
}
