using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

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
        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetAllRoles(Guid id)
        {
            var result = await _serviceManager.UserService.GetUserWithDetailAsync(id);
            return Ok(result);
        }
        [HttpGet("role/{roleId}")]
        public async Task<IActionResult> GetUserInRole(Guid roleId)
        {
            var users = await _serviceManager.RoleService.GetUserInRole(roleId);
            return Ok(users);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id,[FromBody] UserToUpdateDTO user)
        {
            await _serviceManager.UserService.UpdateUserAsync(id, user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _serviceManager.UserService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
