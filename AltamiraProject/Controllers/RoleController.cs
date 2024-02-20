using Contracts.Services;
using Entities.DTO;
using Entities.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltamiraProject.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public RoleController(IServiceManager repositoryService)
        {
            _serviceManager = repositoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _serviceManager.RoleService.GetAllRolesAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var role = await _serviceManager.RoleService.GetRoleByIdAsync(id);
            return Ok(role);
        }
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserInRole(Guid id)
        {
            var role = await _serviceManager.RoleService.GetUserInRole(id);
            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            var role = await _serviceManager.RoleService.CreateRoleAsync(model);
            return Ok(role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleToUpdate model)
        {
            await _serviceManager.RoleService.UpdateRoleAsync(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _serviceManager.RoleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
