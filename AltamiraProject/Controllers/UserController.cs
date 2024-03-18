using AltamiraProject.ApiResponse;
using AltamiraProject.Validation;
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
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _serviceManager.UserService.GetUserByIdAsync(id);
            return Ok(new ApiOkResponse(user));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Artist")]
        [ServiceFilter(typeof(UserAuthorizationFilters))]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody] UserToUpdateDTO user)
        {
            var result = await _serviceManager.UserService.UpdateUserAsync(id, user);
            return Ok(new ApiOkResponse(result));
        }
        [HttpPut("update-user-active")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> UpdateActiveUser([FromBody] UpdateUserActiveRequest request)
        {
            await _serviceManager.UserService.UpdateUserActiveAsync(request);
            return Ok(new ApiOkResponse());
        }
        [HttpPut("update-user-photo")]
        [Authorize(Roles = "Administrador,Artist")]
        public async Task<IActionResult> UpdateUserPhoto([FromBody] UpdateUserPhoto request)
        {
            await _serviceManager.UserService.UpdateUserPhotoAsync(request);
            return Ok(new ApiOkResponse());
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _serviceManager.UserService.DeleteUserAsync(id);
            return Ok(new ApiOkResponse());
        }
        [HttpPost("{id}/addrole/{roleId}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AddRoleToUser([FromRoute]int id,[FromRoute]int roleId)
        {
            await _serviceManager.UserService.AddRoleToUser(roleId, id);
            return Ok(new ApiOkResponse());
        }
    }
}
